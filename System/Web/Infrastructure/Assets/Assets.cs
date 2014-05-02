using System;

namespace Web.Infrastructure.Assets
{
    public static class Assets
    {
        private const String MainFolder = "/Content";

        public static class Scripts
        {
            private const String ScriptsFolder = MainFolder + "/Scripts";

            public static class Components
            {
                private const String ComponentsFolder = ScriptsFolder + "/Components";

                public static Asset Dialog = new ScriptAsset(ComponentsFolder + "/System.Dialog.js");
                public static Asset Grid = new ScriptAsset(ComponentsFolder + "/System.Grid.js");
            }

            public static Asset JQuery = new ScriptAsset(ScriptsFolder + "/jquery-1.10.1.min.js");
            public static Asset JQueryUI = new ScriptAsset(ScriptsFolder + "/jquery-ui-1.10.3.custom.min.js");
            public static Asset Bootstrap = new ScriptAsset(ScriptsFolder + "/bootstrap.min.js");
            public static Asset Modernizer = new ScriptAsset(ScriptsFolder + "/modernizr-2.6.2-respond-1.1.0.min.js");
            public static Asset Main = new ScriptAsset(ScriptsFolder + "/System.js");
        }

        public static class Styles
        {
            private const String StylesFolder = MainFolder + "/Styles";

            public static Asset Bootstrap = new StyleAsset(StylesFolder + "/bootstrap.css");
            public static Asset BootstrapResponsive = new StyleAsset(StylesFolder + "/bootstrap-responsive.css");
            public static Asset JQuery = new StyleAsset(StylesFolder + "/jquery-ui-1.10.3.custom.min.css");
            public static Asset Main = new StyleAsset(StylesFolder + "/main.css");
            
            // Features
            public static Asset Portfolio = new StyleAsset(StylesFolder + "/portfolio.css");
            public static Asset News = new StyleAsset(StylesFolder + "/news.css");

            public static class Grid
            {
                private const String GridFolder = StylesFolder + "/Grid";

                public static Asset GridMain = new StyleAsset(GridFolder + "/Grid.css");
            }

            public static class Controls
            {
                private const String ControlsFolder = StylesFolder + "/Controls";

                public static Asset Fields = new StyleAsset(ControlsFolder + "/fields.css");
            }
        }
    }
}