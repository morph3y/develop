﻿using System;
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

        public void Add<T>(T item) where T : BusinessObject
        {
            DataLayerAdapter.Add(item);
        }
    }
}