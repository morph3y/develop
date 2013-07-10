﻿using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using Entities.Entities;
using Framework.Common.Contracts;

namespace Business.Services.Authentication
{
    public sealed class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService(IObjectService objectService)
        {
            ObjectService = objectService;
        }

        public IObjectService ObjectService { get; set; }

        public bool Authenticate(string userName, string password)
        {
            var users = ObjectService.Get<User>(x => x.UserName == userName);
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
            var hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password.Trim(), "sha1");
            return hashedPassword != null ? hashedPassword.ToLower() : string.Empty;
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
