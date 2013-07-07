using System;
using System.Collections.Generic;
using DAL.Contracts;
using DAL.Expressions;
using Entities.Entities;
using Entities.Expression.Common;

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

        public IList<T> Get<T>(ExpressionType operatorType, string lhv, string rhv) where T : BusinessObject
        {
            var criteria = new CriteraFactory(lhv, rhv).Get(operatorType);
            if (criteria != null)
            {
                using (var session = DataAccessAdapter.Adapter.OpenSession())
                {
                    return session.CreateCriteria<T>().Add(criteria).List<T>();
                }
            }
            return new List<T>();
        }
    }
}
