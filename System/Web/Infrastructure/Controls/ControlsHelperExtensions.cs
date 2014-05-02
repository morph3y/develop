using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Web.Infrastructure.Views;

namespace Web.Infrastructure.Controls
{
    public static class ControlsHelperExtension
    {
        public static FieldArea FieldArea(this HtmlHelper helper, String title)
        {
            return new FieldArea(helper.ViewContext, title);
        }

        public static Form BeginForm(this HtmlHelper helper, String action)
        {
            return new Form(helper.ViewContext, action);
        }

        public static void SubmitButton(this HtmlHelper helper, String caption)
        {
            if (ViewMode.Current != ViewModes.Edit && ViewMode.Current != ViewModes.Create)
            {
                return;
            }
            helper.ViewContext.Writer.Write("<input type='submit' class='btn-submit' value='" + caption + "' />");
        }

        public static void FieldFor(this HtmlHelper helper, String @for)
        {
            helper.ViewContext.Writer.Write("<div class='fld-container'><table><tr><td><div class='fld-caption'>" + @for + "</div></td>");
            if (ViewMode.Current == ViewModes.Create || ViewMode.Current == ViewModes.Edit)
            {
                helper.ViewContext.Writer.Write("<td><div class='fld-value'>");
                helper.ViewContext.Writer.Write(helper.Editor(@for));
                helper.ViewContext.Writer.Write("</div></td></table></div>");
                return;
            }
            helper.ViewContext.Writer.Write("<td><div class='fld-value'>");
            helper.ViewContext.Writer.Write(helper.Display(@for));
            helper.ViewContext.Writer.Write("</div></td></table></div>");
        }
    }
}