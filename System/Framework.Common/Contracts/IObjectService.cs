using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entities.Entities;

namespace Framework.Common.Contracts
{
    public interface IObjectService
    {
        T Get<T>(Guid id) where T : BusinessObject;
        IList<T> Get<T>(Expression<Func<T, bool>> action) where T : BusinessObject;
    }
}
