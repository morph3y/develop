﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entities.Entities.Base;

namespace Contracts.Dal
{
    public interface IDataAccessAdapter
    {
        T Get<T>(int id) where T : BusinessObject;
        void Save<T>(T entity) where T : BusinessObject;
        IEnumerable<T> GetCollection<T>(
            Expression<Func<T, bool>> where,
            Int32? take,
            Expression<Func<T, object>> orderBy,
            Int32? orderDirection
        ) where T : BusinessObject;

        IEnumerable GetCollection(Type type, Int32? take);
        void Delete<T>(Int32 id) where T : BusinessObject;
    }
}
