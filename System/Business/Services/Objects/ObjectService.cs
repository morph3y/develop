using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entities.Entities;
using Framework.Common.Contracts;
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
