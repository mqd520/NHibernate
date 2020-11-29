using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateDemo.WinForm1.IService
{
    public interface IService<T>
    {
        #region Query
        /// <summary>
        /// Query All
        /// </summary>
        /// <returns></returns>
        IList<T> QueryAll();
        #endregion
    }
}
