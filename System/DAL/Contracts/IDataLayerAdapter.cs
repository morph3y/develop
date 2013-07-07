using System;
using System.Collections.Generic;
using Entities.Entities;
using Entities.Expression.Common;

namespace DAL.Contracts
{
    public interface IDataLayerAdapter
    {
        T Get<T>(Guid id) where T : BusinessObject;
        void Add<T>(T item) where T : BusinessObject;
        IList<T> Get<T>(ExpressionType operatorType, string lhv, string rhv) where T : BusinessObject;
    }
}
