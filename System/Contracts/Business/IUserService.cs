using System;
using Entities.Entities.User;

namespace Contracts.Business
{
    public interface IUserService
    {
        Boolean Authenticate(String userName, String password);
        void Save(User userToSave);
    }
}
