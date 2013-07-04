using System;
using Entities.Entities;

namespace DAL.Adapters
{
    public interface IDataLayerAdapter
    {
        T Get<T>(Guid id) where T : BusinessObject;
        void Add<T>(T item) where T : BusinessObject;
    }
}
