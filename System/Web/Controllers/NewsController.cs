using System;
using System.Web.Mvc;
using Web.Models.News;

namespace Web.Controllers
{
    public class NewsController : Controller
    {
        public ActionResult Index()
        {
            var model = new NewsItemCollection();
            model.Add(new NewsItem
                          {
                              Id = Guid.NewGuid(),
                              Text = "Long time has passed since I updated my resume so I decided to throw in some new infromation. Check out the 'Resume' section for an update.",
                              Title = "Resume update"
                          });
            model.Add(new NewsItem
            {
                Id = Guid.NewGuid(),
                Text = "Long time has passed since I updated my resume so I decided to throw in some new infromation. Check out the 'Resume' section for an update.",
                Title = "Resume update"
            });
            return View("News", model);
        }
    }
}
