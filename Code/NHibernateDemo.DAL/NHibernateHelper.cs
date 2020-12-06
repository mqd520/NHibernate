using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernate;
using NHibernate.Cfg;

using Common;

namespace NHibernateDemo.DAL
{
    public static class NHibernateHelper
    {
        #region Property
        public static ISessionFactory SessionFactory { get; private set; } = null;

        public static bool EnableSqlLog { get; set; } = true;

        public static string Path { get; set; } = "";

        private static IList<IInterceptor> Interceptors { get; set; } = new List<IInterceptor>();
        #endregion


        #region Constructor
        static NHibernateHelper()
        {
            Path = AppDomain.CurrentDomain.BaseDirectory + "hibernate.cfg.xml";
        }
        #endregion


        #region Method
        /// <summary>
        /// Init
        /// </summary>
        public static void Init()
        {
            try
            {
                SessionFactory = new Configuration().Configure(Path).BuildSessionFactory();
            }
            catch (Exception e)
            {
                string paramStr = string.Format("Path: {0}", Path);
                ConsoleHelper.WriteLine(
                    ELogCategory.Error,
                    string.Format("NHibernateHelper Build Session Factory Exception: {0}{1}{2}", e.Message, System.Environment.NewLine, paramStr),
                    true,
                    e: e
                );
            }

            if (SessionFactory != null)
            {
                if (EnableSqlLog)
                {
                    Interceptors.Add(new SqlInterceptor());
                }
            }
        }

        /// <summary>
        /// Open Session
        /// </summary>
        /// <returns></returns>
        public static ISession OpenSession()
        {
            ISessionBuilder sb = SessionFactory.WithOptions();

            foreach (var item in Interceptors)
            {
                sb = sb.Interceptor(item);
            }

            return sb.OpenSession();
        }

        /// <summary>
        /// Add Interceptor
        /// </summary>
        /// <param name="interceptor"></param>
        public static void AddInterceptor(IInterceptor interceptor)
        {
            Interceptors.Add(interceptor);
        }
        #endregion
    }
}
