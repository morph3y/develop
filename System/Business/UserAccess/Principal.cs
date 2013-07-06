using System.Security.Principal;

namespace Business.UserAccess
{
    public class Principal : IPrincipal
    {
        public bool IsInRole(string role)
        {
            return false;
        }

        public IIdentity Identity { get; set; }
    }
}