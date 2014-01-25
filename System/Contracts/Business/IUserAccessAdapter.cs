using System;
using Entities.Entities.User;

namespace Contracts.Business
{
    public interface IUserAccessAdapter
    {
        User GetUser(String userName);
        void SaveUser(User user);
    }
}
