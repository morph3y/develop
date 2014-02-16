using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Contracts.Business;
using Contracts.Dal;
using DAL.Exceptions;
using Entities.Entities.Base;
using Entities.Entities.User;
using FluentNHibernate.Utils;
using NHibernate;
using NHibernate.Criterion;

namespace DAL
{
    internal sealed class DataAccessAdapter : IDataAccessAdapter, IUserAccessAdapter
    {
        private readonly ISessionFactory _sessionFactory;

        public DataAccessAdapter()
        {
            _sessionFactory = FluentEnvironment.GetConfiguration().BuildSessionFactory();
        }

        public T Get<T>(int id) where T : BusinessObject
        {
            T toReturn;
            using(var dataAccessSession = _sessionFactory.OpenSession())
            {
                toReturn = dataAccessSession.Get<T>(id);
            }
            return toReturn;
        }

        public void Save<T>(T entity) where T : BusinessObject
        {
            using (var dataAccessSession = _sessionFactory.OpenSession())
            {
                try
                {
                    using (var transaction = dataAccessSession.BeginTransaction())
                    {
                        dataAccessSession.SaveOrUpdate(entity);
                        transaction.Commit();
                    }
                }
                catch(Exception e)
                {
                    throw new EntitySaveException(e);
                }
            }
        }

        public IEnumerable<T> GetCollection<T>(
            Expression<Func<T, bool>> @where, 
            int? take, 
            Expression<Func<T, object>> orderBy, 
            int? orderDirection
        ) where T : BusinessObject
        {
            IEnumerable<T> toReturn;
            using (var dataAccessSession = _sessionFactory.OpenSession())
            {
                var query = QueryOver.Of<T>();
                if (where != null)
                {
                    query.Where(where);
                }
                if (orderBy != null)
                {
                    if (orderDirection.HasValue)
                    {
                        if (orderDirection == 0)
                        {
                            query.OrderBy(orderBy).Asc();
                        }
                        if (orderDirection == 1)
                        {
                            query.OrderBy(orderBy).Desc();
                        }
                    }
                    else
                    {
                        query.OrderBy(orderBy);
                    }
                }
                if (take.HasValue)
                {
                    query.Take(take.Value);
                }
                toReturn = query.GetExecutableQueryOver(dataAccessSession).List<T>();
            }
            return toReturn;
        }

        public IEnumerable GetCollection(Type type, Int32? take)
        {
            using (var dataAccessSession = _sessionFactory.OpenSession())
            {
                var criteria = dataAccessSession.CreateCriteria(type);
                if (take.HasValue)
                {
                    criteria.SetFetchSize(take.Value);
                }
                return criteria.List();
            }
        }

        public void Delete<T>(Int32 id) where T : BusinessObject
        {
            using (var dataAccessSession = _sessionFactory.OpenSession())
            {
                using (var transaction = dataAccessSession.BeginTransaction())
                {
                    dataAccessSession.Delete(dataAccessSession.Load<T>(id));
                    transaction.Commit();
                }
            }
        }

        public void Delete<T>(List<Int32> ids) where T : BusinessObject
        {
            using (var dataAccessSession = _sessionFactory.OpenStatelessSession())
            {
                using(var transaction = dataAccessSession.BeginTransaction())
                {
                    var entities = GetCollection<T>(x=>x.Id.IsIn(ids), null, null, null);
                    if (entities == null) return;
                    foreach (var entity in entities)
                    {
                        dataAccessSession.Delete(entity);
                    }
                    transaction.Commit();
                }
            }
        }

        #region UserAccessAdapter members
        public User GetUser(string userName)
        {
            User toReturn;
            using (var dataAccessSession = _sessionFactory.OpenSession())
            {
                toReturn = dataAccessSession.QueryOver<User>().Where(x => x.UserName == userName).SingleOrDefault();
            }

            return toReturn;
        }

        public void SaveUser(User user)
        {
            using (var dataAccessSession = _sessionFactory.OpenSession())
            {
                try
                {
                    using (var transaction = dataAccessSession.BeginTransaction())
                    {
                        transaction.Begin();
                        dataAccessSession.SaveOrUpdate(user);
                        transaction.Commit();
                    }
                }
                catch (Exception e)
                {
                    throw new EntitySaveException(e);
                }
            }
        }
        #endregion
    }
}
