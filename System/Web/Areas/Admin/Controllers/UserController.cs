using System;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Contracts.Business;
using Framework.Common;

namespace Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        private IUserService UserService
        {
            get { return _userService ?? (_userService = ApplicationEnvironment.Resolve<IUserService>()); }
        }

        public String Login(String username, String password)
        {
            var serializer = new JavaScriptSerializer();
            var authResult = UserService.Authenticate(username, password);
            if (!authResult)
            {
                return serializer.Serialize(new { authenticated = false });
            }
            var cookie = FormsAuthentication.GetAuthCookie(username, false);
            Response.Cookies.Add(cookie);
            return serializer.Serialize(new { authenticated = true });
        }

        public String Logout()
        {
            var serializer = new JavaScriptSerializer();
            FormsAuthentication.SignOut();
            return serializer.Serialize(new { authenticated = false });
        }
    }
}
