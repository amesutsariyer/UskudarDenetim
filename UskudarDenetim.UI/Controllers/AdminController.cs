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
        private Repository.Interface.GenericRepository<Address> _addressRepository;
        private Repository.Interface.GenericRepository<Contact> _contactRepository;
        private Repository.Interface.GenericRepository<SocialMedia> _socailMediaRepository;

        public AdminController()
        {
            _employeeRepository = new Repository.GenericRepository<Employee>();
            _documentRepository = new Repository.GenericRepository<Document>();
            _addressRepository = new Repository.GenericRepository<Address>();
            _contactRepository = new Repository.GenericRepository<Contact>();
            _socailMediaRepository = new Repository.GenericRepository<SocialMedia>();
        }
        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<IDRole>>();

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

        [Authorize]
        [HttpGet]
        public ActionResult UpdateContact()
        {
         var socialMediaList= _socailMediaRepository.GetAll().Select(c => new ModelSocialMedia(){
             SocialMediaId = c.Id,
             SocialMediaName = c.Name,
             IconClassName =c.IconClassName,
             Url = c.Url
         }).ToList();
            var contact = _contactRepository.GetAll().ToList();
             
            ModelContact model = new ModelContact() {
                LocalePhoneNumber =contact[0].LocalePhoneNumber,
                PhoneNumber  = contact[0].PhoneNumber,
                FaxNumber = contact[0].FaxNumber,
                EmailAddress = contact[0].EmailAddress,
                Id  = contact[0].Id
            };
            //il ve İlçe bilgileri Dropdown Get
            model.Address = new ModelAddress()
            {
                AddressDetail = contact[0].Address.AddressDetail,
                Header = contact[0].Address.Header ,
                Name= contact[0].Address.Name,
                Id =contact[0].Address.Id
               
            };
            
            model.Address.DistrictSelectList = GetDistrictDDL();
            model.Address.CitySelectList = GetCityDDL();
            model.ContactSocialMedias = socialMediaList;

            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult UpdateContact(ModelContact model)
        {
            try
            {
                var contact = new Contact() {
                   
                    Id = model.Id,
                    AddressId =model.Address.Id,
                    IsActive =true,
                    EmailAddress = model.EmailAddress,
                    PhoneNumber = model.PhoneNumber,
                    FaxNumber = model.FaxNumber,
                    LocalePhoneNumber = model.LocalePhoneNumber,
                    IsDeleted = false
                };
                var address = new Address()
                {
                    Id = model.Address.Id,
                    DistrictId = 418,
                    Header = model.Address.Header,
                    Latitude = "41.001698",
                    Longitude = "29.075744",
                    Name = model.Address.Name,
                    AddressDetail = model.Address.AddressDetail

                };
                _addressRepository.Update(address);
                _contactRepository.Update(contact);
                return Json(new { Success = true, Message = "Güncelleme İşlemi Başarılı." });
            }
            catch (Exception)
            {

                return Json(new { Success = true, Message = "Güncelleme İşlemi Başarılı." });
            }
        }
  

    }
}