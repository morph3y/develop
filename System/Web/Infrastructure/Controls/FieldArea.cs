using System;
using System.Web.Mvc;

namespace Web.Infrastructure.Controls
{
    public class FieldArea : IDisposable
    {
        private readonly ViewContext _viewContext;

        public FieldArea(ViewContext viewContext, String title)
        {
            _viewContext = viewContext;

            _viewContext.Writer.Write("<div class='fieldarea'>" +
                                        "<div class='fldaheader'>" + title + "</div>" +
                                        "<div class='fldacontent'>");
        }

        public void Dispose()
        {
            _viewContext.Writer.Write(  "</div>" +
                                      "</div>");
        }
    }
}