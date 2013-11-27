using System;
using System.Web.Mvc;

namespace Web.Infrastructure.Assets
{
    public abstract class Asset
    {
        public String Tag { get; set; }
        public String Path { get; set; }

        public String Render(UrlHelper urlHelper)
        {
            return String.Format(Tag, urlHelper.Content("~" + Path));
        }
    }
}