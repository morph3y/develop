using System;

namespace Entities.Entities.User
{
    public class User
    {
        public virtual Int32 Id { get; set; }
        public virtual String UserName { get; set; }
        public virtual String Password { get; set; }
        public virtual String Name { get; set; }
    }
}
