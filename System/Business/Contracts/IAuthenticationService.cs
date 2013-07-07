using System.Security.Principal;
using System.Web;

namespace Business.Contracts
{
    public interface IAuthenticationService
    {
        bool Authenticate(string userName, string password);
        string HashPassword(string password);
        HttpCookie CreateCookie(string userName);
        IPrincipal CreatePrincipal(string userName);
        void SignOut();
    }
}
