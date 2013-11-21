using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Contracts.Business;
using Entities.Entities.Base.Resume;
using Framework.Common;

namespace Web.Controllers
{
    public class ResumeController : Controller
    {
        private IObjectService ObjectService
        {
            get { return ApplicationEnvironment.Resolve<IObjectService>(); }
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
