﻿using System.Security.Principal;

namespace Business.UserAccess
{
    public class Identity : IIdentity
    {
        public string Name { get; set; }

        public string AuthenticationType { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}