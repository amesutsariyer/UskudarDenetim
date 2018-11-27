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
using UskudarDenetim.Core.Extensions;

namespace UskudarDenetim.UI.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View("Home");
        }

        public ActionResult Login()
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<IDRole>>();

            if (!roleManager.RoleExists("admin"))
                roleManager.Create(new IDRole("admin"));
            return View();
        }
        public ActionResult LogOut()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        #region Contact
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
        #endregion

        #region Employee
        public ActionResult Employees()
        {
            // return EmployeesModel 
            //Tüm çalışanlar Model ile gönderilmeli
            //IsPArent Patron burda göndercez her türlü
            var model = new List<ModelEmployee>()
            {
                 new ModelEmployee()
                 {
                     Id= Guid.NewGuid(),
                     BirthDate= DateTime.Now,
                     FirstName="Ufuk",
                     LastName ="Sevincer",
                     Profession = "Denetçi Yardımcısı",
                     IsParent=false,
                     Title = "Junior",
                     PhoneNumber="538 649 91 64",
                     Email ="test@uskudardenetim.com.tr"

                 },
                 new ModelEmployee()
                 {
                         Id= Guid.NewGuid(),
                     BirthDate= DateTime.Now,
                     FirstName="Harun",
                     LastName ="Baştürk",
                     Profession = "Yeminli Mali Müşavir",
                     IsParent=false,
                     Title = "Senior",
                     PhoneNumber="535 346 28 78",
                     Email ="test@uskudardenetim2.com.tr"

                 },
                 new ModelEmployee()
                 {
                      Id= Guid.NewGuid(),
                     BirthDate= DateTime.Now,
                     FirstName="Harun",
                     LastName ="Baştürk",
                     Profession = "Bilgisayar Mühendisi",
                     IsParent=false,
                     Title = "Junior",
                     PhoneNumber="535 346 28 78",
                     Email ="test@uskudardenetim3.com.tr"

                 }
            };
            return View(model);
        }
        [HttpGet]
        public ActionResult UpdateEmployee(string id)
        {
            Guid idG = id.ConvertToGuid();
            var model = new ModelEmployee()
            {

                Id = Guid.NewGuid(),
                BirthDate = DateTime.Now,
                FirstName = "Harun",
                LastName = "Baştürk",
                Profession = "Bilgisayar Mühendisi",
                IsParent = false,
                Title = "Junior",
                PhoneNumber = "535 346 28 78",
                Email = "test@uskudardenetim3.com.tr"
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateEmployee(ModelEmployee model)
        {
            //convertTo entity and save 
            try
            {
                return Json("Ok");
            }
            catch (Exception)
            {
                return Json("false");

            }

        }
        #endregion

    }
}