using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Contracts.Business;
using Contracts.Dal;
using Entities.Entities.Base;
using Framework.Common;
using Framework.Common.Query;

namespace Business.Services
{
    internal sealed class ObjectService : IObjectService
    {
        private readonly IDataAccessAdapter _dataAccessAdapter;
        public ObjectService()
        {
            _dataAccessAdapter = ApplicationEnvironment.Resolve<IDataAccessAdapter>();
        }

        public void Save<T>(T entity) where T : BusinessObject
        {
            entity.DateModified = DateTime.Now;
            _dataAccessAdapter.Save(entity);
        }

        public T Get<T>(int id) where T : BusinessObject
        {
            return _dataAccessAdapter.Get<T>(id);
        }

        public IEnumerable<T> GetCollection<T>() where T : BusinessObject
        {
            return GetCollection<T>(null, null, null, null);
        }

        public IEnumerable<T> GetCollection<T>(Expression<Func<T, bool>> where) where T : BusinessObject
        {
            return GetCollection(where, null);
        }

        public IEnumerable<T> GetCollection<T>(Expression<Func<T, bool>> where, Int32? take) where T : BusinessObject
        {
            return GetCollection(where, take, null, null);
        }

        public IEnumerable<T> GetCollection<T>(Int32? take) where T : BusinessObject
        {
            return GetCollection<T>(null, take);
        }

        public IEnumerable<T> GetCollection<T>(
            Expression<Func<T, bool>> where, 
            Int32? take, 
            Expression<Func<T, object>> orderBy, 
            OrderByDirection? orderDirection
        ) where T : BusinessObject
        {
            return _dataAccessAdapter.GetCollection(
                where, 
                take, 
                orderBy, 
                orderDirection.HasValue ? (Int32)orderDirection : (Int32?)null);
        }

        public IEnumerable<T> GetCollection<T>(Expression<Func<T, object>> orderBy, OrderByDirection? orderDirection) where T : BusinessObject
        {
            return GetCollection(null, null, orderBy, orderDirection);
        }

        public IEnumerable<T> GetCollection<T>(Int32? take, Expression<Func<T, object>> orderBy, OrderByDirection? orderDirection) where T : BusinessObject
        {
            return GetCollection(null, take, orderBy, orderDirection);
        }
    }
}
