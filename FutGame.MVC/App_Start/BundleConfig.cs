using System.Web.Optimization;
using dotless.Core;


namespace FutGame.MVC
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Public/Vendor/Jquery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Public/Vendor/Jquery/jquery.unobtrusive*",
                        "~/Public/Vendor/Jquery/jquery.validate*"));
               
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Public/Scripts/modernizr-*"));

            //Main Style
            bundles.Add(new StyleBundle("~/content/css").Include(
                        "~/Public/Styles/main.less",
                        "~/Public/Styles/main.css"));

            //Add Bootstrap
            bundles.Add(new ScriptBundle("~/bootstrap/js").Include(
                        "~/Public/Vendor/Bootstrap/js/bootstrap.js"));

            bundles.Add(new StyleBundle("~/bootstrap/css").Include(
                        "~/Public/Vendor/Bootstrap/css/bootstrap.css",
                        "~/Public/Vendor/Bootstrap/css/bootstrap-theme.css"));
            
        }
    }
}