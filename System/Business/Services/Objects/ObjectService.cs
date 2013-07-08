using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Business.Contracts;
using DAL.Contracts;
using Entities.Entities;
using Ninject;

namespace Business.Services.Objects
{
    internal sealed class ObjectService : IObjectService
    {
        [Inject]
        public IDataLayerAdapter DataLayerAdapter { get; set; }

        public T Get<T>(Guid id) where T : BusinessObject
        {
            return DataLayerAdapter.Get<T>(id);
        }

        public IList<T> Get<T>(Expression<Func<T, bool>> action) where T : BusinessObject
        {
            return DataLayerAdapter.Get(action);
        }
    }
}
