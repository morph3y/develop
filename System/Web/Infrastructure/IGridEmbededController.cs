using System;
using System.Web.Mvc;

namespace Web.Infrastructure
{
    public interface IGridEmbededController : IController
    {
        PartialViewResult GetPage(Int32? page, Int32? pageSize);
    }
}