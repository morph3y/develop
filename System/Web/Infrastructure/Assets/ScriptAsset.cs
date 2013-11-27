using System;

namespace Web.Infrastructure.Assets
{
    public class ScriptAsset : Asset
    {
        public ScriptAsset(String path)
        {
            Tag = "<script src='{0}'></script>";
            Path = path;
        }
    }
}