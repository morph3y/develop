using System.Web.Mvc;
using Business.Contracts;
using Ninject;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        [HttpPost]
        public JsonResult Authenticate(string userName, string password)
        {
            if (AuthenticationService.Authenticate(userName, password) && !User.Identity.IsAuthenticated)
            {
                var identity = AuthenticationService.CreatePrincipal(userName);
                var authCookie = AuthenticationService.CreateCookie(userName);

                Response.Cookies.Add(authCookie);
                HttpContext.User = identity;
                return Json(new { result = true, data = "Welcome " + userName + "!" });
            }
            return Json(new { result = false, data = "" });
        }

        [HttpPost]
        public void Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                AuthenticationService.SignOut();
            }
        }
    }
}
