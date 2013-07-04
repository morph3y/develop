using System;
using Entities.Entities;

namespace Business.Contracts
{
    public interface IObjectService
    {
        T Get<T>(Guid id) where T : BusinessObject;
        void Add<T>(T item) where T : BusinessObject;
    }
}
