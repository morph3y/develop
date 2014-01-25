using System;
using Business.Crypt;
using Contracts.Business;
using Entities.Entities.User;
using Framework.Common;

namespace Business.Services
{
    internal sealed class UserService : IUserService
    {
        private IUserAccessAdapter _userAccessAdapter;
        private IUserAccessAdapter UserAccessAdapter
        {
            get { return _userAccessAdapter ?? (_userAccessAdapter = ApplicationEnvironment.Resolve<IUserAccessAdapter>()); }
        }

        private Cryptography _crypt;
        private Cryptography Crypt
        {
            get { return _crypt ?? (_crypt = new Cryptography()); }
        }

        public Boolean Authenticate(String userName, String password)
        {
            var user = UserAccessAdapter.GetUser(userName);
            return ValidatePassword(password, user.Password);
        }

        private Boolean ValidatePassword(String password, String userPassword)
        {
            return Crypt.Compare(userPassword, password);
        }

        public void Save(User userToSave)
        {
            userToSave.Password = Crypt.Encode(userToSave.Password);
            UserAccessAdapter.SaveUser(userToSave);
        }
    }
}
