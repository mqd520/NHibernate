using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;

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
    }
}
