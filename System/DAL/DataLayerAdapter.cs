using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Contracts;
using Entities.Entities;
using NHibernate.Criterion;

namespace DAL
{
    internal sealed class DataLayerAdapter : IDataLayerAdapter
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
    }
}
