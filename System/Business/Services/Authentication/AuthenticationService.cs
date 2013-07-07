﻿using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using Business.Contracts;
using Entities;
using Entities.Entities;
using Entities.Expression.Common;
using Ninject;

namespace Business.Services.Authentication
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        [Inject]
        public IObjectService ObjectService { get; set; }

        public bool Authenticate(string userName, string password)
        {
            var users = ObjectService.Get<User>(ExpressionType.Equals, PropertyUtil.GetPropertyName<User>(x=>x.UserName), userName);
            if (users.Any() && users.Count == 1)
            {
                if (HashPassword(password) == users.First().Password)
                {
                    return true;
                }
            }
            return false;
        }

        private string HashPassword(string password)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(password.Trim(), "sha1");
        }

        public HttpCookie CreateCookie(string userName)
        {
            return FormsAuthentication.GetAuthCookie(userName, false);
        }

        public IPrincipal CreatePrincipal(string userName)
        {
            return new GenericPrincipal(new GenericIdentity(userName), new string[0]);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
