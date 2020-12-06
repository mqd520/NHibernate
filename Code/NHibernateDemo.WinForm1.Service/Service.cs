using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        #region Query Single
        /// <summary>
        /// Query
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T QuerySingle(object id)
        {
            return Repository.QuerySingle(id);
        }

        /// <summary>
        /// Query Single
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public T QuerySingle(Expression<Func<T, bool>> where)
        {
            return Repository.QuerySingle(where);
        }

        /// <summary>
        /// Query Single
        /// </summary>
        /// <param name="wheres"></param>
        /// <returns></returns>
        public T QuerySingle(IEnumerable<Expression<Func<T, bool>>> wheres)
        {
            return Repository.QuerySingle(wheres);
        }
        #endregion


        #region Query All
        /// <summary>
        /// Query All
        /// </summary>
        /// <returns></returns>
        public IList<T> QueryAll()
        {
            return Repository.QueryAll();
        }

        /// <summary>
        /// Query All
        /// </summary>
        /// <param name="keySelector"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        public IList<T> QueryAll<TKey>(Expression<Func<T, TKey>> keySelector, bool asc)
        {
            return Repository.QueryAll(keySelector, asc);
        }

        /// <summary>
        /// Query All
        /// </summary>
        /// <param name="lsWhere"></param>
        /// <returns></returns>
        public IList<T> QueryAll(Expression<Func<T, bool>> where)
        {
            return Repository.QueryAll(where);
        }

        /// <summary>
        /// Query All
        /// </summary>
        /// <param name="lsWhere"></param>
        /// <returns></returns>
        public IList<T> QueryAll(IList<Expression<Func<T, bool>>> lsWhere)
        {
            return Repository.QueryAll(lsWhere);
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
            return Repository.QueryAll(lsWhere, keySelector, asc);
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
            return Repository.QueryAll(where, keySelector, asc);
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
            return Repository.QueryPaging(page, size, out count);
        }

        /// <summary>
        /// Query Paging
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IList<T> QueryPaging<TKey>(int page, int size, out int count, Expression<Func<T, TKey>> keySelector, bool asc)
        {
            return Repository.QueryPaging(page, size, out count, keySelector, asc);
        }

        /// <summary>
        /// Query Paging
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="count"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<T> QueryPaging(int page, int size, out int count, Expression<Func<T, bool>> where)
        {
            return Repository.QueryPaging(page, size, out count, where);
        }

        /// <summary>
        /// Query Paging
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="count"></param>
        /// <param name="lsWhere"></param>
        /// <returns></returns>
        public IList<T> QueryPaging(int page, int size, out int count, IList<Expression<Func<T, bool>>> lsWhere)
        {
            return Repository.QueryPaging(page, size, out count, lsWhere);
        }

        /// <summary>
        /// Query Paging
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="count"></param>
        /// <param name="lsWhere"></param>
        /// <param name="keySelector"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        public IList<T> QueryPaging<TKey>(int page, int size, out int count, IList<Expression<Func<T, bool>>> lsWhere, Expression<Func<T, TKey>> keySelector, bool asc)
        {
            return Repository.QueryPaging(page, size, out count, lsWhere, keySelector, asc);
        }

        /// <summary>
        /// Query Paging
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="count"></param>
        /// <param name="where"></param>
        /// <param name="keySelector"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        public IList<T> QueryPaging<TKey>(int page, int size, out int count, Expression<Func<T, bool>> where, Expression<Func<T, TKey>> keySelector, bool asc)
        {
            return Repository.QueryPaging(page, size, out count, where, keySelector, asc);
        }
        #endregion
        #endregion


        #region Add
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public object Add(T entity)
        {
            return Repository.Add(entity);
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public IList<object> Add(IList<T> entities)
        {
            return Repository.Add(entities);
        }
        #endregion


        #region Update
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Update(T entity)
        {
            Repository.Update(entity);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public void Update(IList<T> entities)
        {
            Repository.Update(entities);
        }
        #endregion


        #region Delete
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            Repository.Delete(entity);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entities"></param>
        public void Delete(IEnumerable<T> entities)
        {
            Repository.Delete(entities);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="key"></param>
        public void Delete(object key)
        {
            Repository.Delete(key);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="keys"></param>
        public void Delete(IEnumerable<object> keys)
        {
            Repository.Delete(keys);
        }
        #endregion
    }
}
