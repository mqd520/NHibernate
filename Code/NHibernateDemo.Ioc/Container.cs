using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Autofac;

using NHibernateDemo.IRepository;
using NHibernateDemo.Repository;
using NHibernateDemo.WinForm1.IService;
using NHibernateDemo.WinForm1.Service;

namespace NHibernateDemo.Ioc
{
    public class Container
    {
        public static IContainer Instance { get; private set; }


        /// <summary>
        /// Init
        /// </summary>
        /// <returns></returns>
        public static void Init()
        {
            var builder = new ContainerBuilder();

            List<Assembly> ls = new List<Assembly>();
            ls.Add(Assembly.Load("NHibernateDemo.IRepository"));
            ls.Add(Assembly.Load("NHibernateDemo.Repository"));
            ls.Add(Assembly.Load("NHibernateDemo.WinForm1.IService"));
            ls.Add(Assembly.Load("NHibernateDemo.WinForm1.Service"));
            builder.RegisterAssemblyTypes(ls.ToArray())
                .Where(x => x.Name.EndsWith("Repository") || x.Name.EndsWith("Service"))
                .Where(x => x.IsClass)
                .AsImplementedInterfaces();

            Instance = builder.Build();
        }
    }
}
