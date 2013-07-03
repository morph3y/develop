using System;

namespace Entities.Entities
{
    public abstract class BusinessObject
    {
        public virtual Guid Id { get; protected set; }
    }
}
