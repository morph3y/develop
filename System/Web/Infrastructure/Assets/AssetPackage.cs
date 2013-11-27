using System.Collections.Generic;

namespace Web.Infrastructure.Assets
{
    public static class AssetPackage
    {
        // Styles
        public static IList<Asset> MainStylePackage = new List<Asset>
                                        {
                                            Assets.Styles.Bootstrap,
                                            Assets.Styles.BootstrapResponsive,
                                            Assets.Styles.JQuery,
                                            Assets.Styles.Main
                                        };
        // Scripts
        public static IList<Asset> MainScriptPackage = new List<Asset>
                                        {
                                            Assets.Scripts.JQuery,
                                            Assets.Scripts.JQueryUI,
                                            Assets.Scripts.Bootstrap,
                                            Assets.Scripts.Modernizer,
                                            Assets.Scripts.Main
                                        }; 
    }
}