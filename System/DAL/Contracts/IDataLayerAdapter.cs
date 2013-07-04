using System;
using Entities.Entities;

namespace DAL.Contracts
{
    public interface IDataLayerAdapter
    {
        T Get<T>(Guid id) where T : BusinessObject;
        void Add<T>(T item) where T : BusinessObject;
    }
}
