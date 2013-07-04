using System;
using DAL.Contracts;
using Entities.Entities;

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
    }
}
