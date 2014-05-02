using System;
using System.Web.Mvc;
using Contracts.Business;
using Entities.Entities.Base;
using Framework.Common;
using Web.Infrastructure.Views;

namespace Web.Areas.Admin.Controllers.Framework
{
    [ViewMode]
    public class EntityController<T> : AdminBaseController where T : BusinessObject
    {
        private IObjectService _objectService;
        protected IObjectService ObjectService
        {
            get { return _objectService ?? (_objectService = ApplicationEnvironment.Resolve<IObjectService>()); }
        }

        [ActionName("Index")]
        [HttpGet]
        public virtual ActionResult Index()
        {
            return View(GetListViewName());
        }

        [ActionName("View")]
        [HttpGet]
        public virtual ActionResult Display(Int32 id)
        {
            var entity = ObjectService.Get<T>(id);
            return View(GetDetailViewName(), entity);
        }

        [ActionName("Edit")]
        [HttpGet]
        public virtual ActionResult Edit(Int32 id)
        {
            var entity = ObjectService.Get<T>(id);
            return View(GetDetailViewName(), entity);
        }

        [ActionName("Delete")]
        [HttpPost]
        public virtual ActionResult Delete(Int32 id)
        {
            ObjectService.Delete<T>(id);
            return RedirectToAction("Index");
        }

        protected internal virtual String GetDetailViewName()
        {
            return "DetailPage";
        }

        protected internal virtual String GetListViewName()
        {
            return "Inventory";
        }
    }
}
