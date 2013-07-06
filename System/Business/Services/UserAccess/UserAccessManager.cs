using Business.Contracts;

namespace Business.Services.UserAccess
{
    public class UserAccessManager : IUserAccessManager
    {
        public bool Authenticate(string userName, string password)
        {
            return true;
        }
    }
}
