using System;
using System.Web.Mvc;
using Web.Infrastructure.Filters;

namespace Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        [AjaxOnly]
        public String Login(String username, String password)
        {
            return String.Empty;
        }
    }
}
