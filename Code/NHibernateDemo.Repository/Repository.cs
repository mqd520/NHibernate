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
        #region Query Single
        /// <summary>
        /// Query
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T QuerySingle(object id)
        {
            using (var session = OpenSession())
            {
                return session.Get<T>(id);
            }
        }

        /// <summary>
        /// Query Single
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public T QuerySingle(Expression<Func<T, bool>> where)
        {
            using (var session = OpenSession())
            {
                return session.Query<T>().Where(where).FirstOrDefault();
            }
        }

        /// <summary>
        /// Query Single
        /// </summary>
        /// <param name="wheres"></param>
        /// <returns></returns>
        public T QuerySingle(IEnumerable<Expression<Func<T, bool>>> wheres)
        {
            using (var session = OpenSession())
            {
                var query = session.Query<T>();
                foreach (var item in wheres)
                {
                    query = query.Where(item);
                }

                return query.FirstOrDefault();
            }
        }
        #endregion


        #region Query All
        /// <summary>
        /// Query All
        /// </summary>
        /// <returns></returns>
        public IList<T> QueryAll()
        {
            using (var session = OpenSession())
            {
                return session.Query<T>().ToList();
            }
        }

        /// <summary>
        /// Query All
        /// </summary>
        /// <param name="keySelector"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        public IList<T> QueryAll<TKey>(Expression<Func<T, TKey>> keySelector, bool asc)
        {
            using (var session = OpenSession())
            {
                IList<T> ls = new List<T>();

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
        }

        /// <summary>
        /// Query All
        /// </summary>
        /// <param name="lsWhere"></param>
        /// <returns></returns>
        public IList<T> QueryAll(Expression<Func<T, bool>> where)
        {
            using (var session = OpenSession())
            {
                var query = session.Query<T>();
                query = query.Where(where);

                return query.ToList();
            }
        }

        /// <summary>
        /// Query All
        /// </summary>
        /// <param name="lsWhere"></param>
        /// <returns></returns>
        public IList<T> QueryAll(IList<Expression<Func<T, bool>>> lsWhere)
        {
            using (var session = OpenSession())
            {
                var query = session.Query<T>();
                foreach (var item in lsWhere)
                {
                    query = query.Where(item);
                }

                return query.ToList();
            }
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
            using (var session = OpenSession())
            {
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
            using (var session = OpenSession())
            {
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
            using (var session = OpenSession())
            {
                count = 0;
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
            using (var session = OpenSession())
            {
                count = 0;
                var query = session.Query<T>();

                count = query.Count();
                if (count > 0)
                {
                    if (asc)
                    {
                        query = query.OrderBy(keySelector);
                    }
                    else
                    {
                        query = query.OrderByDescending(keySelector);
                    }
                    query = query.Skip((page - 1) * size).Take(size);

                    return query.ToList();
                }
                else
                {
                    return new List<T>();
                }
            }
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
            using (var session = OpenSession())
            {
                count = 0;
                var query = session.Query<T>();
                query = query.Where(where);

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
            using (var session = OpenSession())
            {
                count = 0;
                var query = session.Query<T>();
                foreach (var item in lsWhere)
                {
                    query = query.Where(item);
                }

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
            using (var session = OpenSession())
            {
                count = 0;
                var query = session.Query<T>();
                foreach (var item in lsWhere)
                {
                    query = query.Where(item);
                }

                count = query.Count();
                if (count > 0)
                {
                    if (asc)
                    {
                        query = query.OrderBy(keySelector);
                    }
                    else
                    {
                        query = query.OrderByDescending(keySelector);
                    }
                    query = query.Skip((page - 1) * size).Take(size);

                    return query.ToList();
                }
                else
                {
                    return new List<T>();
                }
            }
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
            using (var session = OpenSession())
            {
                count = 0;
                var query = session.Query<T>();
                query = query.Where(where);

                count = query.Count();
                if (count > 0)
                {
                    if (asc)
                    {
                        query = query.OrderBy(keySelector);
                    }
                    else
                    {
                        query = query.OrderByDescending(keySelector);
                    }
                    query = query.Skip((page - 1) * size).Take(size);

                    return query.ToList();
                }
                else
                {
                    return new List<T>();
                }
            }
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
            object obj = new object();

            using (var session = OpenSession())
            {
                obj = session.Save(entity);
                session.Flush();
            }

            return obj;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public IList<object> Add(IList<T> entities)
        {
            using (var session = OpenSession())
            {
                IList<object> ls = new List<object>();

                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in entities)
                        {
                            object obj = session.Save(item);
                            ls.Add(obj);
                        }
                        transaction.Commit();
                    }
                    catch (HibernateException)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

                return ls;
            }
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
            using (var session = OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public void Update(IList<T> entities)
        {
            using (var session = OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in entities)
                        {
                            session.SaveOrUpdate(item);
                        }
                        transaction.Commit();
                    }
                    catch (HibernateException e)
                    {
                        transaction.Rollback();
                        throw e;
                    }
                }
            }
        }
        #endregion


        #region Delete
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            using (var session = OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entities"></param>
        public void Delete(IEnumerable<T> entities)
        {
            using (var session = OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in entities)
                        {
                            session.Delete(item);
                        }
                        transaction.Commit();
                    }
                    catch (HibernateException e)
                    {
                        transaction.Rollback();
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="key"></param>
        public void Delete(object key)
        {
            using (var session = OpenSession())
            {
                var entity = session.Get<T>(key);
                if (entity != null)
                {
                    session.Delete(entity);
                    session.Flush();
                }
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="keys"></param>
        public void Delete(IEnumerable<object> keys)
        {
            using (var session = OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IList<T> ls = new List<T>();

                    try
                    {
                        foreach (var item in keys)
                        {
                            var entity = session.Get<T>(item);
                            ls.Add(entity);
                        }

                        foreach (var item in ls)
                        {
                            session.Delete(item);
                        }

                        transaction.Commit();
                    }
                    catch (HibernateException e)
                    {
                        transaction.Rollback();
                        throw e;
                    }
                }
            }
        }
        #endregion
    }
}
