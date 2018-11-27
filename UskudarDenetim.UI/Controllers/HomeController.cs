using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UskudarDenetim.UI.Models;

namespace UskudarDenetim.UI.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            //var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            //var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<IDRole>>();

            //if (!roleManager.RoleExists("admin"))
            //    roleManager.Create(new IDRole("admin"));
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View(new ModelContact());
        }
    


    }
}