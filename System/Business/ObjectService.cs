using System;
using DAL.BusinessContext;
using Entities.Entities;

namespace Business
{
    public class ObjectService : IObjectService
    {
        public T Get<T>(Guid id) where T : BusinessObject
        {
            var t = new BusinessContext();
            return t.Get<T>(id);
        }

        public void Add<T>(T item) where T : BusinessObject
        {
            var t = new BusinessContext();
            t.Add(item);
        }
    }
}
