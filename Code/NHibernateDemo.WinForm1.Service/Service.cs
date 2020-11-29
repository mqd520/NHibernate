using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernateDemo.IRepository;
using NHibernateDemo.Repository;
using NHibernateDemo.WinForm1.IService;

namespace NHibernateDemo.WinForm1.Service
{
    public class Service<T> : IService<T>
    {
        #region Property
        protected IRepository<T> Repository { get; set; } = new Repository<T>();
        #endregion


        #region Query
        public IList<T> QueryAll()
        {
            return Repository.QueryAll();
        }
        #endregion
    }
}
