using System.Web;
using System.Web.Optimization;

namespace UMS_Portal
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/PanelTheme/CSS_BUNDLE").Include(
                      "~/Content/PanelTheme/css/bootstrap.min.css",
                      "~/Content/PanelTheme/css/font-awesome.min.css",
                      "~/Content/PanelTheme/css/owl.carousel.css",
                      "~/Content/PanelTheme/css/owl.theme.css",
                      "~/Content/PanelTheme/css/owl.transitions.css",
                      "~/Content/PanelTheme/css/meanmenu/meanmenu.min.css",
                      "~/Content/PanelTheme/css/animate.css",
                      "~/Content/PanelTheme/css/normalize.css",
                      "~/Content/PanelTheme/css/scrollbar/jquery.mCustomScrollbar.min.css",
                      "~/Content/PanelTheme/css/jvectormap/jquery-jvectormap-2.0.3.css",
                      "~/Content/PanelTheme/css/notika-custom-icon.css",
                      "~/Content/PanelTheme/css/jquery.dataTables.min.css",
                      "~/Content/PanelTheme/css/wave/waves.min.css",
                      "~/Content/PanelTheme/css/main.css",
                      "~/Content/PanelTheme/style.css",
                      "~/Content/PanelTheme/css/responsive.css",
                      "~/Content/CustomPanelStyles.css"
                      ));

            bundles.Add(new ScriptBundle("~/Content/PanelTheme/SCRIPTS_BUNDLE").Include(
                      "~/Content/PanelTheme/js/vendor/jquery-1.12.4.min.js",
                      "~/Content/PanelTheme/js/bootstrap.min.js",
                      "~/Content/PanelTheme/js/wow.min.js",
                      "~/Content/PanelTheme/js/jquery-price-slider.js",
                      "~/Content/PanelTheme/js/owl.carousel.min.js",
                      "~/Content/PanelTheme/js/jquery.scrollUp.min.js",
                      "~/Content/PanelTheme/js/meanmenu/jquery.meanmenu.js",
                      "~/Content/PanelTheme/js/counterup/jquery.counterup.min.js",
                      "~/Content/PanelTheme/js/counterup/waypoints.min.js",
                      "~/Content/PanelTheme/js/counterup/counterup-active.js",
                      "~/Content/PanelTheme/js/scrollbar/jquery.mCustomScrollbar.concat.min.js",
                      "~/Content/PanelTheme/js/jvectormap/jquery-jvectormap-2.0.2.min.js",
                      "~/Content/PanelTheme/js/jvectormap/jquery-jvectormap-world-mill-en.js",
                      "~/Content/PanelTheme/js/jvectormap/jvectormap-active.js",
                      "~/Content/PanelTheme/js/sparkline/jquery.sparkline.min.js",
                      "~/Content/PanelTheme/js/sparkline/sparkline-active.js",
                      "~/Content/PanelTheme/js/flot/jquery.flot.js",
                      "~/Content/PanelTheme/js/flot/jquery.flot.resize.js",
                      "~/Content/PanelTheme/js/flot/curvedLines.js",
                      "~/Content/PanelTheme/js/flot/flot-active.js",
                      "~/Content/PanelTheme/js/knob/jquery.knob.js",
                      "~/Content/PanelTheme/js/knob/jquery.appear.js",
                      "~/Content/PanelTheme/js/knob/knob-active.js",
                      "~/Content/PanelTheme/js/wave/waves.min.js",
                      "~/Content/PanelTheme/js/wave/wave-active.js",
                      "~/Content/PanelTheme/js/todo/jquery.todo.js",
                      "~/Content/PanelTheme/js/plugins.js",
                      "~/Content/PanelTheme/js/data-table/jquery.dataTables.min.js",
                      "~/Content/PanelTheme/js/data-table/data-table-act.js",
                      "~/Content/PanelTheme/js/chat/moment.min.js",
                      "~/Content/PanelTheme/js/chat/jquery.chat.js",
                      "~/Content/PanelTheme/js/main.js"
                      //,
                      //"~/Content/PanelTheme/js/tawk-chat.js"
                      ));
        }
    }
}
