using System;
using Entities.Entities.User;

namespace Contracts.Dal
{
    public interface IUserAccessAdapter
    {
        User GetUser(String userName);
        void SaveUser(User user);
    }
}
