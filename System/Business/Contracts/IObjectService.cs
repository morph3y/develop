using System;
using System.Collections.Generic;
using Entities.Entities;
using Entities.Expression.Common;

namespace Business.Contracts
{
    public interface IObjectService
    {
        T Get<T>(Guid id) where T : BusinessObject;
        IList<T> Get<T>(ExpressionType operatorType, string lhv, string rhv) where T : BusinessObject;
    }
}
