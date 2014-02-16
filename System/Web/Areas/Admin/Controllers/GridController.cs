using System;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class GridController : Controller
    {
        public ActionResult RedirectToEntityController(String actionName, String entityName, Int32? entityId)
        {
            return RedirectToAction(actionName, entityName, entityId.HasValue ? new { id = entityId.Value } : null);
        }
    }
}
