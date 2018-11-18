using System.Web;
using System.Web.Optimization;

namespace UskudarDenetim.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").IncludeDirectory(
                        "~/Scripts", "*.js", true));

        

           
            bundles.Add(new StyleBundle("~/Content/css").IncludeDirectory("~/Content", "*.css",true));
            bundles.Add(new StyleBundle("~/Content/skin").IncludeDirectory("~/Content/skins/blue", "*.css",true));
            bundles.Add(new StyleBundle("~/Content/additional").IncludeDirectory("~/Content/additional-css/attorney", "*.css",true));
            // bundles.Add(new StyleBundle("~/Content/dark").IncludeDirectory("~/Content/skins/blue", "*.css ", true));

        }
    }
}
