using System.Web.Mvc;
using Business.Contracts;
using Ninject;

namespace Web.Controllers
{
    public class LoginController : ActionController
    {
        [Inject]
        public IUserAccessManager UserAccessManager { get; set; }

        [Inject]
        public IAuthentication Authentication { get; set; }

        [HttpPost]
        public ActionResult Authenticate(string userName, string password)
        {
            if (UserAccessManager.Authenticate(userName, password))
            {
                Authentication.SetCookies(userName);
                return PartialView("Login");
            }
            else
            {
                return PartialView("Login");
            }
        }

        [HttpPost]
        public ActionResult Logout()
        {
            Authentication.DeleteCookies();
            return PartialView("Logout");
        }
    }
}
