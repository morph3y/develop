using System.Collections.Generic;
using System.Web.Mvc;
using Entities.Entities;

namespace Web.Controllers
{
    public class PortfolioController : Controller
    {
        public ActionResult Index()
        {
            return View(new List<PortfolioItem> { new PortfolioItem { Description = "asdasdadsad", ImageUrl = "asd.jpg"} });
        }
    }
}
