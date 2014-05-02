using System;
using System.Web.Mvc;
using Contracts.Business;
using Entities.Entities.Base;
using Framework.Common;
using Web.Infrastructure.Views;

namespace Web.Areas.Admin.Controllers.Framework
{
    [ViewMode]
    public class EntityController<T> : AdminBaseController where T : BusinessObject , new()
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
        public virtual ActionResult Delete(Int32 id)
        {
            ObjectService.Delete<T>(id);
            return RedirectToAction("Index");
        }

        [ActionName("Update")]
        [HttpPost]
        public ActionResult Update(Int32 id)
        {
            var model = ObjectService.Get<T>(id);
            TryUpdateModel(model);
            ObjectService.Save(model);

            return RedirectToAction("Index");
        }

        [ActionName("Create")]
        [HttpGet]
        public ActionResult Create()
        {
            return View(GetDetailViewName());
        }

        [ActionName("Create")]
        [HttpPost]
        public ActionResult Insert()
        {
            var model = new T();
            TryUpdateModel(model);
            ObjectService.Save(model);
            return View(GetListViewName());
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
