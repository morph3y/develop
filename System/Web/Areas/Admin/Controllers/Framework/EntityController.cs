using System;
using System.Web.Mvc;
using Contracts.Business;
using Entities.Entities.Base;
using Framework.Common;

namespace Web.Areas.Admin.Controllers.Framework
{
    public class EntityController<T> : AdminBaseController where T : BusinessObject
    {
        private IObjectService _objectService;
        public IObjectService ObjectService
        {
            get { return _objectService ?? (_objectService = ApplicationEnvironment.Resolve<IObjectService>()); }
        }

        [ActionName("Index")]
        public virtual ActionResult Index()
        {
            return View(GetListViewName());
        }

        [ActionName("View")]
        public ActionResult Display(Int32 id)
        {
            var entity = ObjectService.Get<T>(id);
            return View(GetDetailViewName(), entity);
        }

        [ActionName("Edit")]
        public ActionResult Edit(Int32 id)
        {
            var entity = ObjectService.Get<T>(id);
            return View(GetDetailViewName(), entity);
        }

        [ActionName("Delete")]
        public ActionResult Delete(Int32 id)
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
