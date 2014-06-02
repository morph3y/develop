using System.Web.Mvc;
using Contracts.Business;
using Framework.Common;

namespace Web.Controllers
{
    public abstract class PresentationController : Controller
    {
        protected IObjectService ObjectService
        {
            get { return ApplicationEnvironment.Resolve<IObjectService>(); }
        }
    }
}
