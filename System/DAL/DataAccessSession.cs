using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Contracts.Dal;
using Entities.Entities.Base;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Criterion;

namespace DAL
{
    internal sealed class DataAccessSession : IDataAccessSession
    {
        private readonly ISession _sessionFactory;

        public DataAccessSession()
            : this(FluentEnvironment.GetConfiguration())
        { }

        private DataAccessSession(FluentConfiguration configuration)
        {
            _sessionFactory = configuration.BuildSessionFactory().OpenSession();
        }

        public T Get<T>(int id) where T : BusinessObject
        {
            return _sessionFactory.Get<T>(id);
        }

        public void Save<T>(T entity) where T : BusinessObject
        {
            _sessionFactory.SaveOrUpdate(entity);
        }

        public IEnumerable<T> GetCollection<T>(
            Expression<Func<T, bool>> where,
            Int32? take,
            Expression<Func<T, object>> orderBy,
            Int32? orderDirection
        ) where T : BusinessObject
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
            return query.GetExecutableQueryOver(_sessionFactory).List<T>();
        }
    }
}
