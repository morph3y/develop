using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entities.Entities.Base;
using Framework.Common.Query;

namespace Contracts.Business
{
    public interface IObjectService
    {
        void Save<T>(T entity) where T : BusinessObject;

        T Get<T>(int id) where T : BusinessObject;
        IEnumerable<T> GetCollection<T>() where T : BusinessObject;
        IEnumerable<T> GetCollection<T>(Expression<Func<T, bool>> where) where T : BusinessObject;
        IEnumerable<T> GetCollection<T>(Expression<Func<T, bool>> where, Int32? take) where T : BusinessObject;
        IEnumerable<T> GetCollection<T>(Expression<Func<T, bool>> where, Int32? take, Expression<Func<T, object>> orderBy,
            OrderByDirection? orderDirection)
            where T : BusinessObject;
        IEnumerable<T> GetCollection<T>(Int32? take) where T : BusinessObject;
        IEnumerable<T> GetCollection<T>(Expression<Func<T, object>> orderBy, OrderByDirection? orderDirection) where T : BusinessObject;
        IEnumerable<T> GetCollection<T>(Int32? take, Expression<Func<T, object>> orderBy, OrderByDirection? orderDirection) where T : BusinessObject;
    }
}
