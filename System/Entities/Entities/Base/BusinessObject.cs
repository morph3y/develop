﻿using System;

namespace Entities.Entities.Base
{
    public abstract class BusinessObject
    {
        public virtual Int32 Id { get; protected set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateModified { get; set; }
    }
}
