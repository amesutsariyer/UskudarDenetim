using System.Web;
using System.Web.Optimization;

namespace UskudarDenetim.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                  "~/Content/responsive.css",
                  "~/Content/meanmenu.css",
                  "~/Content/prettyPhoto.css",
                  "~/Content/animations.css",
                  "~/Content/font-awesome.min.css",
                  "~/Content/shortcodes.css",
                  "~/Content/additional-css/attorney/style.css",
                  "~/Content/style.css",
                  "~/Content/skins/blueturquoise/style.css", 
                  "~/Content/layerslider.css"
                      ));
            /*
             
             */


            bundles.Add(new ScriptBundle("~/bundles/javascript").Include(
                   "~/Scripts/jquery-1.10.2.min.js",
                   "~/Scripts/jquery-migrate.min.js",
                   "~/Scripts/jquery-migrate.min.js",
                   "~/Scripts/preloader.js",
                   "~/Scripts/pace.min.js",
                   "~/Scripts/jquery.tabs.min.js",
                   "~/Scripts/jquery.tipTip.minified.js",
                   "~/Scripts/jquery.parallax-1.1.3.js",
                   "~/Scripts/jquery-easing-1.3.js",
                   "~/Scripts/jquery.inview.js",
                   "~/Scripts/jquery.viewport.js",
                   "~/Scripts/jquery.nav.js",
                   "~/Scripts/jquery.jcarousel.min.js",
                   "~/Scripts/jquery.carouFredSel-6.2.1-packed.js",
                   "~/Scripts/jquery.isotope.min.js",
                   "~/Scripts/jquery.prettyPhoto.js",
                   "~/Scripts/masonry.pkgd.min.js",
                   "~/Scripts/layerslider.transitions.js",
                   "~/Scripts/layerslider.kreaturamedia.jquery.js",
                   "~/Scripts/greensock.js",
                   "~/Scripts/responsive-nav.js",
                   "~/Scripts/jquery.meanmenu.min.js",
                   "~/Scripts/jquery.sticky.js",
                   "~/Scripts/jquery.ui.totop.min.js",
                   "~/Scripts/retina.js",
                   "~/Scripts/jquery.nicescroll.min.js",
                   "~/Scripts/custom.js",
                   "~/Scripts/twitter/jquery.tweet.min.js",
                   "~/Scripts/jquery.validate.min.js",
                   "~/Scripts/jquery.tipTip.minified.js"
               ));
        }
    }
}
