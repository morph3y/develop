using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entities.Entities;
using Framework.Common.Contracts;
using NHibernate.Criterion;

namespace DAL
{
    public sealed class DataLayerAdapter : IDataLayerAdapter
    {
        public T Get<T>(Guid id) where T : BusinessObject
        {
            using (var session = DataAccessAdapter.Adapter.OpenSession())
            {
                return session.Get<T>(id);
            }
        }

        public void Add<T>(T item) where T : BusinessObject
        {
            using (var session = DataAccessAdapter.Adapter.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(item);
                    transaction.Commit();
                }
            }
        }

        public IList<T> Get<T>(Expression<Func<T, bool>> action) where T : BusinessObject
        {
            using (var session = DataAccessAdapter.Adapter.OpenSession())
            {
                return session.CreateCriteria<T>().Add(Restrictions.Where(action)).List<T>();
            }
        }

        public IList<T> Get<T>(Expression<Func<bool>> action) where T : BusinessObject
        {
            using (var session = DataAccessAdapter.Adapter.OpenSession())
            {
                return session.CreateCriteria<T>().Add(Restrictions.Where(action)).List<T>();
            }
        }

        public IList<T> Get<T>() where T : BusinessObject
        {
            using (var session = DataAccessAdapter.Adapter.OpenSession())
            {
                return session.QueryOver<T>().List();
            }
        }

        public IList<T> Get<T>(Int32 page, Int32 pageSize, Expression<Func<T, object>> orderByProperty) where T : BusinessObject
        {
            using (var session = DataAccessAdapter.Adapter.OpenSession())
            {
                return
                    session.CreateCriteria<T>().AddOrder(Order.Desc(Projections.Property(orderByProperty))).SetFirstResult(
                        page*pageSize).SetMaxResults(pageSize).List<T>();
            }
        } 
    }
}
