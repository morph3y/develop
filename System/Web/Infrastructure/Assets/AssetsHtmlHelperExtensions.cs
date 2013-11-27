using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Web.Infrastructure.Assets
{
    public static class AssetsHtmlHelperExtensions
    {
        public static MvcHtmlString RenderAsset(this HtmlHelper helper, Asset asset)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            return new MvcHtmlString(asset.Render(urlHelper));
        }

        public static MvcHtmlString RenderAssetPackage(this HtmlHelper helper, IList<Asset> packageItems)
        {
            var allStyles = new StringBuilder();
            foreach (var packageItem in packageItems)
            {
                allStyles.Append(RenderAsset(helper, packageItem));
            }
            return new MvcHtmlString(allStyles.ToString());
        }
    }
}