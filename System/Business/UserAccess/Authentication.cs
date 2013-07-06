using System;
using System.Web;
using System.Web.Security;
using Business.Contracts;

namespace Business.UserAccess
{
    internal sealed class Authentication : IAuthentication
    {
        public void SetCookies(string userName)
        {
            var identityTicket = new FormsAuthenticationTicket(1, userName, DateTime.Now, DateTime.Now.AddDays(60), true, "");
            var encryptedIdentityTicket = FormsAuthentication.Encrypt(identityTicket);
            var identityCookie = new HttpCookie("identity", encryptedIdentityTicket) { Expires = DateTime.Now.AddDays(60) };
            HttpContext.Current.Response.Cookies.Add(identityCookie);

            FormsAuthentication.SetAuthCookie(userName, false);
        }

        public void DeleteCookies()
        {
            HttpContext.Current.Response.Cookies.Clear();
            FormsAuthentication.SignOut();
        }
    }
}
