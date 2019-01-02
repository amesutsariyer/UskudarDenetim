using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UskudarDenetim.Core.Extensions;
using UskudarDenetim.UI.Identity;
using UskudarDenetim.UI.Models;
using System.IO;
using UskudarDenetim.Repository.EF;
using System.Security.Claims;

namespace UskudarDenetim.UI.Controllers
{
    public class AdminController : BaseController
    {
        private Repository.Interface.GenericRepository<Employee> _employeeRepository;
        private Repository.Interface.GenericRepository<Document> _documentRepository;

        public AdminController()
        {
            _employeeRepository = new Repository.GenericRepository<Employee>();
            _documentRepository = new Repository.GenericRepository<Document>();
        }
        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<IDRole>>();

            //if (!roleManager.RoleExists("admin"))
            //    roleManager.Create(new IDRole("admin"));

            //var user = new IDUser()
            //{
            //    UserName = "uskudardenetim",
            //    Email ="info@uskudardenetim.com"

            //};
            //var result = userManager.Create(user, "uskudardenetim");
            //if (result.Succeeded)
            //{
            //    userManager.AddToRole(user.Id, "admin");
            //}

            return View("Home");
        }

        public ActionResult Login(ModelLogin model)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
      

            var user = userManager.Find(model.Username, model.Password);
            if (user!=null)
            {
                var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, ""),
                new Claim(ClaimTypes.Email, model.Username),
                new Claim(ClaimTypes.Country, "Turkey")
            },
            "ApplicationCookie");
                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

            }
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult LogOut()
        {
            return View();
        }
        public ActionResult Register()
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
            return View(model);
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