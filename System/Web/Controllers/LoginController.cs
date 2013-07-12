using System.Web.Mvc;
using Framework.Common.Contracts;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        private IAuthenticationService AuthenticationService { get; set; }

        public LoginController(IAuthenticationService authenticationService)
        {
            AuthenticationService = authenticationService;
        }

        [HttpPost]
        public JsonResult Authenticate(string userName, string password)
        {
            if (AuthenticationService.Authenticate(userName, password) && !User.Identity.IsAuthenticated)
            {
                var identity = AuthenticationService.CreatePrincipal(userName);
                var authCookie = AuthenticationService.CreateCookie(userName);

                Response.Cookies.Add(authCookie);
                HttpContext.User = identity;
            }
            return null;
        }

        public ActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                AuthenticationService.SignOut();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
