using System;

namespace Entities.Entities.Base
{
    public class BusinessObject
    {
        public virtual Int32 Id { get; protected set; }
        public virtual DateTime DateCreated { get; set; }
    }
}
