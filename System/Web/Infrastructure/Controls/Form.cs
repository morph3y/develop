using System;
using System.Web.Mvc;

namespace Web.Infrastructure.Controls
{
    public class Form : IDisposable
    {
        private readonly ViewContext _viewContext;

        public Form(ViewContext viewContext, String action)
        {
            _viewContext = viewContext;
            var urlHelper = new UrlHelper(viewContext.RequestContext);
            viewContext.Writer.Write("<form action='" + urlHelper.Action(action) + "' method='post'>");
        }

        public void Dispose()
        {
            _viewContext.Writer.Write("</form>");
        }
    }
}