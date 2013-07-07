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
        public ActionResult Authenticate(string userName, string password)
        {
            var hashedPassword = AuthenticationService.HashPassword(password);
            if (AuthenticationService.Authenticate(userName, hashedPassword))
            {
                var identity = AuthenticationService.CreatePrincipal(userName);
                var authCookie = AuthenticationService.CreateCookie(userName);

                Response.Cookies.Add(authCookie);
                HttpContext.User = identity;
            }
            return PartialView("Login");
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
