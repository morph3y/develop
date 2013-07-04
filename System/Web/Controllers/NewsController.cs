using System.Web.Mvc;
using Business.Contracts;
using Entities.Entities;
using Ninject;

namespace Web.Controllers
{
    public class NewsController : Controller
    {
        [Inject]
        public IObjectService ObjectService { get; set; }

        public ActionResult Index()
        {
            var entity = new NewsItem
                             {
                                 Text =
                                     "Long time has passed since I updated my resume so I decided to throw in some new infromation. Check out the 'Resume' section for an update.",
                                 Title = "Resume update"
                             };
            ObjectService.Add(entity);
            var model = ObjectService.Get<NewsItem>(entity.Id);
            
            return View("News", model);
        }
    }
}
