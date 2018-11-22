﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UskudarDenetim.Business.Entity;
using UskudarDenetim.Core;
using UskudarDenetim.UI.Identity;

namespace UskudarDenetim.UI.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<IDRole>>();

            if (!roleManager.RoleExists("admin"))
                roleManager.Create(new IDRole("admin"));
            return View();
        }

        public ActionResult About()
        {
            //Address tablosunu GetAddresses methodu yardımıyla businesstan talep ettik.Business katmanı repo katmanına istek atarak Tüm adresleri çekti.
            AddressBusiness business = new AddressBusiness();
            var model =   business.GetAddresses().FirstOrDefault();
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}