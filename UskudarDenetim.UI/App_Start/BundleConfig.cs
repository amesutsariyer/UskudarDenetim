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
                  "~/Content/style.css",
                  "~/Content/bootstrap.css",
                  "~/Content/shortcodes.css",
                  "~/Content/additional-css/attorney/style.css",
                  "~/Content/skins/blueturquoise/style.css",
                  "~/Content/layerslider.css",
                  "~/Content/responsive.css",
                  "~/Content/meanmenu.css",
                  "~/Content/prettyPhoto.css",
                  "~/Content/animations.css",
                  "~/Content/font-awesome.min.css"
                      ));
            /*
             
	   
    
	<link id="default-css" rel="stylesheet" href="style.css" type="text/css" media="all" />
	<link id="shortcodes-css" rel="stylesheet" href="shortcodes.css" type="text/css" media="all"/>
    <link id="additional-css" rel="stylesheet" href="additional-css/attorney/style.css" type="text/css" media="all"/>
	<link id="skin-css" rel="stylesheet" href="skins/brown/style.css" type="text/css" media="all"/>
    <link id="layer-slider" rel="stylesheet"  href="css/layerslider.css" media="all" />
	<link rel="stylesheet" href="responsive.css" type="text/css" media="all"/>
	<link rel="stylesheet" href="css/meanmenu.css" type="text/css" media="all"/>
	<link rel="stylesheet" href="css/prettyPhoto.css" type="text/css" media="screen"/>
    <link rel="stylesheet" href="css/animations.css" type="text/css" media="all" />
	<link rel="stylesheet" href="css/font-awesome.min.css" type="text/css" />
    
             */


            bundles.Add(new ScriptBundle("~/bundles/javascript").Include(
                   "~/Scripts/jquery-1.10.2.min.js",
                   "~/Scripts/bootstrap.js",
                      "~/Scripts/jquery.unobtrusive-ajax.min.js",
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
                   "~/Scripts/jquery.bxslider.min.js",
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
            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
            //~/Scripts/inputmask/dependencyLibs/inputmask.dependencyLib.js",  //if not using jquery
            "~/Scripts/inputmask/inputmask.js",
            "~/Scripts/inputmask/jquery.inputmask.js",
            "~/Scripts/inputmask/inputmask.extensions.js",
            "~/Scripts/inputmask/inputmask.date.extensions.js",
            //and other extensions you want to include
            "~/Scripts/inputmask/inputmask.numeric.extensions.js"));
        }
    }
}
