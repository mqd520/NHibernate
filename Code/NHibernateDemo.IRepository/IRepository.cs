using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateDemo.IRepository
{
    public interface IRepository<T>
    {
        #region Query
        #region Query All
        /// <summary>
        /// Query All
        /// </summary>
        /// <returns></returns>
        IList<T> QueryAll();

        /// <summary>
        /// Query All
        /// </summary>
        /// <param name="keySelector"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        IList<T> QueryAll<TKey>(Expression<Func<T, TKey>> keySelector, bool asc);

        /// <summary>
        /// Query All
        /// </summary>
        /// <param name="lsWhere"></param>
        /// <returns></returns>
        IList<T> QueryAll(Expression<Func<T, bool>> where);

        /// <summary>
        /// Query All
        /// </summary>
        /// <param name="lsWhere"></param>
        /// <returns></returns>
        IList<T> QueryAll(IList<Expression<Func<T, bool>>> lsWhere);

        /// <summary>
        /// Query All
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="lsWhere"></param>
        /// <param name="keySelector"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        IList<T> QueryAll<TKey>(IList<Expression<Func<T, bool>>> lsWhere, Expression<Func<T, TKey>> keySelector, bool asc);

        /// <summary>
        /// Query All
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="where"></param>
        /// <param name="keySelector"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        IList<T> QueryAll<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> keySelector, bool asc);
        #endregion


        #region Query Paging
        /// <summary>
        /// Query Paging
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        IList<T> QueryPaging(int page, int size, out int count);
        #endregion
        #endregion
    }
}
