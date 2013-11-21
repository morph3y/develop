using System.Collections.Generic;
using System.Web.Mvc;
using Entities.Entities.Base.Portfolio;

namespace Web.Controllers
{
    public class PortfolioController : Controller
    {
        public ActionResult Index()
        {
            return View(new List<Portfolio> { new Portfolio { Description = "asdasdadsad", ImageUrl = "asd.jpg"} });
        }
    }
}
