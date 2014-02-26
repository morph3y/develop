using System;
using System.Web;
using System.Web.Mvc;

namespace Web.Infrastructure.Assets
{
    public abstract class Asset
    {
        public String Tag { get; set; }
        public String Path { get; set; }
        public Boolean IsRendered
        {
            get
            {
                return HttpContext.Current.Items[Path] != null && Boolean.Parse(HttpContext.Current.Items[Path].ToString()) ;
            }
            set
            {
                if (HttpContext.Current.Items.Contains(Path))
                {
                    HttpContext.Current.Items[Path] = value;
                    return;
                }
                HttpContext.Current.Items.Add(Path, value);
            }
        }

        public virtual String Render(UrlHelper urlHelper)
        {
            if (IsRendered)
            {
                return String.Empty;
            }
            IsRendered = true;
            return String.Format(Tag, urlHelper.Content("~" + Path));
        }
    }
}