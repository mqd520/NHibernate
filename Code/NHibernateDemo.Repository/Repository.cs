using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using NHibernate;

using NHibernateDemo.DAL;
using NHibernateDemo.IRepository;

namespace NHibernateDemo.Repository
{
    public class Repository<T> : IRepository<T>
    {
        #region Common
        /// <summary>
        /// Open Session
        /// </summary>
        /// <returns></returns>
        protected ISession OpenSession()
        {
            return NHibernateHelper.OpenSession();
        }
        #endregion


        #region Query
        #region Query All
        /// <summary>
        /// Query All
        /// </summary>
        /// <returns></returns>
        public IList<T> QueryAll()
        {
            var session = OpenSession();
            var query = session.Query<T>();

            return query.ToList();
        }

        /// <summary>
        /// Query All
        /// </summary>
        /// <param name="keySelector"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        public IList<T> QueryAll<TKey>(Expression<Func<T, TKey>> keySelector, bool asc)
        {
            var session = OpenSession();
            var query = session.Query<T>();
            if (asc)
            {
                query = query.OrderBy(keySelector);
            }
            else
            {
                query = query.OrderByDescending(keySelector);
            }

            return query.ToList();
        }

        /// <summary>
        /// Query All
        /// </summary>
        /// <param name="lsWhere"></param>
        /// <returns></returns>
        public IList<T> QueryAll(Expression<Func<T, bool>> where)
        {
            var session = OpenSession();
            var query = session.Query<T>();
            query = query.Where(where);

            return query.ToList();
        }

        /// <summary>
        /// Query All
        /// </summary>
        /// <param name="lsWhere"></param>
        /// <returns></returns>
        public IList<T> QueryAll(IList<Expression<Func<T, bool>>> lsWhere)
        {
            var session = OpenSession();
            var query = session.Query<T>();
            foreach (var item in lsWhere)
            {
                query = query.Where(item);
            }

            return query.ToList();
        }

        /// <summary>
        /// Query All
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="lsWhere"></param>
        /// <param name="keySelector"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        public IList<T> QueryAll<TKey>(IList<Expression<Func<T, bool>>> lsWhere, Expression<Func<T, TKey>> keySelector, bool asc)
        {
            var session = OpenSession();
            var query = session.Query<T>();
            foreach (var item in lsWhere)
            {
                query = query.Where(item);
            }
            if (asc)
            {
                query = query.OrderBy(keySelector);
            }
            else
            {
                query = query.OrderByDescending(keySelector);
            }

            return query.ToList();
        }

        /// <summary>
        /// Query All
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="where"></param>
        /// <param name="keySelector"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        public IList<T> QueryAll<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> keySelector, bool asc)
        {
            var session = OpenSession();
            var query = session.Query<T>();
            query = query.Where(where);
            if (asc)
            {
                query = query.OrderBy(keySelector);
            }
            else
            {
                query = query.OrderByDescending(keySelector);
            }

            return query.ToList();
        }
        #endregion


        #region Query Paging
        /// <summary>
        /// Query Paging
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IList<T> QueryPaging(int page, int size, out int count)
        {
            count = 0;

            var session = OpenSession();
            var query = session.Query<T>();
            count = query.Count();
            if (count > 0)
            {
                query = query.Skip((page - 1) * size).Take(size);
                return query.ToList();
            }
            else
            {
                return new List<T>();
            }
        }
        #endregion
        #endregion
    }
}
