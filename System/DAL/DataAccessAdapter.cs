using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Contracts.Dal;
using DAL.Exceptions;
using Entities.Entities.Base;
using NHibernate;
using NHibernate.Criterion;

namespace DAL
{
    internal sealed class DataAccessAdapter : IDataAccessAdapter
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
                        transaction.Begin();
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
    }
}
