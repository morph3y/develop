using System.Web.Mvc;
using Entities.Entities.Portfolio;
using Framework.Common.Query;

namespace Web.Controllers
{
    public class PortfolioController : PresentationController
    {
        public ActionResult Index()
        {
            /*ObjectService.Save(new Portfolio
                                   {
                                       Description = "Now that there is the Tec-9, a crappy spray gun from South Miami. This gun is advertised as the most popular gun in American crime. Do you believe that shit? It actually says that in the little book that comes with it: the most popular gun in American crime. Like they're actually proud of that shit. ",
                                       ImageUrl = "123.jpg",
                                       Url = "http://alexdenysenko.com/portHTML"
                                   });
            */
            return View(ObjectService.GetCollection<Portfolio>(x=>x.DateCreated, OrderByDirection.Descending));
        }
    }
}
