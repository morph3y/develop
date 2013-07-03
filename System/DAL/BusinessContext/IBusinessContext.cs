using System;
using Entities.Entities;

namespace DAL.BusinessContext
{
    public interface IBusinessContext
    {
        T Get<T>(Guid id) where T : BusinessObject;
    }
}
