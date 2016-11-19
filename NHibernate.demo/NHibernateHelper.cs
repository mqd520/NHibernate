using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.SqlCommand;

namespace NHibernate.demo
{
    public class NHibernateHelper
    {
        private static readonly ISessionFactory _sessionFactory;

        static NHibernateHelper()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "hibernate.cfg.xml";
            _sessionFactory = new Configuration().Configure(path).BuildSessionFactory();
        }

        public static ISession CreateSession()
        {
            return _sessionFactory.OpenSession();
        }
        public static ISession CreateSession(Action<SqlString> action)
        {
            CustomWatcher watch = new CustomWatcher
            {
                PreSQL = action
            };
            return _sessionFactory.OpenSession(watch);
        }
    }

    public class CustomWatcher : EmptyInterceptor
    {
        public override SqlString OnPrepareStatement(SqlString sql)
        {
            if (PreSQL != null)
            {
                PreSQL.Invoke(sql);
            }
            return base.OnPrepareStatement(sql);
        }

        public Action<SqlString> PreSQL { get; set; }
    }
}
