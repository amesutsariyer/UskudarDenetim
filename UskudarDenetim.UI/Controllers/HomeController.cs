using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UskudarDenetim.Business.Entity;
using UskudarDenetim.Core;
using UskudarDenetim.UI.Identity;
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
            return View();
        }
        //[Authorize]
        [HttpGet]
        public ActionResult UpdateContact()
        {
            ModelContact model = new ModelContact();
            //il ve İlçe bilgileri Dropdown Get
            model.Address.DistrictSelectList = GetDistrictDDL();
            model.Address.CitySelectList = GetCityDDL();
            model.ContactSocialMedias = new List<ModelSocialMedia>() {
                new ModelSocialMedia()
                {
                    SocialMediaId  = Guid.NewGuid(),
                    SocialMediaName = "Facebook",
                    Url ="www.facebook.com"
                },
                new ModelSocialMedia()
                {
                    SocialMediaId  = Guid.NewGuid(),
                    SocialMediaName = "Twitter",
                    Url ="www.twiter.com"
                },
                new ModelSocialMedia()
                {
                    SocialMediaId= Guid.NewGuid(),
                    SocialMediaName = "Instagram",
                    Url ="www.instagram.com"
                }

            };
            return View("admin/UpdateContact",model);
        }
        [HttpPost]
        public JsonResult UpdateContact(ModelContact model)
        {
            return Json("Ok");
        }
        [HttpPost]
        public JsonResult UpdateSocialMedia(ModelSocialMedia model)
        {
            return Json("ok");
        }


    }
}