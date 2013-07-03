using System.Web.Mvc;
using Business;
using Entities.Entities;

namespace Web.Controllers
{
    public class NewsController : Controller
    {
        public ActionResult Index()
        {
            var test = new ObjectService();
            var entity = new NewsItem
                             {
                                 Text =
                                     "Long time has passed since I updated my resume so I decided to throw in some new infromation. Check out the 'Resume' section for an update.",
                                 Title = "Resume update"
                             };
            test.Add(entity);
            var model = test.Get<NewsItem>(entity.Id);
            
            return View("News", model);
        }
    }
}
