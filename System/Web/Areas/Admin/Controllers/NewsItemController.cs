using System;
using System.Web.Mvc;
using Entities.Entities;
using Web.Areas.Admin.Controllers.Framework;

namespace Web.Areas.Admin.Controllers
{
    public sealed class NewsItemController : EntityController<NewsItem>
    {
        [ActionName("Update")]
        [HttpPost]
        public ActionResult Update(Int32 id)
        {
            var model = ObjectService.Get<NewsItem>(id);
            TryUpdateModel(model);
            ObjectService.Save(model);

            return RedirectToAction("Index");
        }
    }
}
