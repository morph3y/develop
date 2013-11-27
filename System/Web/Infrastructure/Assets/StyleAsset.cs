using System;

namespace Web.Infrastructure.Assets
{
    public class StyleAsset : Asset
    {
        public StyleAsset(String path)
        {
            Path = path;
            Tag = "<link rel='stylesheet' type='text/css' href='{0}'>";
        }
    }
}