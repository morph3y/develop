using System;
using System.Collections.Generic;
using Business.Contracts;
using DAL.Contracts;
using Entities.Entities;
using Entities.Expression.Common;
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

        public IList<T> Get<T>(ExpressionType operatorType, string lhv, string rhv) where T : BusinessObject
        {
            return DataLayerAdapter.Get<T>(operatorType, lhv, rhv);
        }
    }
}
