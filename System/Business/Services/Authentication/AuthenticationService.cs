using System.Security.Principal;
using System.Web;
using System.Web.Security;
using Business.Contracts;

namespace Business.Services.Authentication
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        public bool Authenticate(string userName, string password)
        {
            return true;
        }

        public string HashPassword(string password)
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
