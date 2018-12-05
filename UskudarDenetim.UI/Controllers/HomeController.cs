using ExhangeRateService.Entity;
using ExhangeRateService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UskudarDenetim.Repository;
using UskudarDenetim.Repository.EF;
using UskudarDenetim.Repository.Entity;
using UskudarDenetim.Repository.Interface;
using UskudarDenetim.UI.Models;

namespace UskudarDenetim.UI.Controllers
{
    public class HomeController : BaseController
    {
        private IGenericRepository<Address> _addressRepository;
        private IGenericRepository<Contact> _contactRepository;
        public HomeController()
        {
            _addressRepository = new GenericRepository<Address>();
            _contactRepository = new GenericRepository<Contact>();
        }
        public ActionResult Index()
        {
            //var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            //var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<IDRole>>();

            //if (!roleManager.RoleExists("admin"))
            //    roleManager.Create(new IDRole("admin"));

            IQueryable<Address> addressRepo = _addressRepository.GetAll();
            var asd = addressRepo.ToList();
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

        public ActionResult TopBar()
        {
            try
            {
                List<Contact> contactRepoList = _contactRepository.GetAll().ToList();
                ModelTopBar model = new ModelTopBar()
                {
                    Email = contactRepoList[0].EmailAddress,
                    Phone = contactRepoList[0].PhoneNumber,
                };
                foreach (var sm in contactRepoList[0].ContactSocialMedias)
                {
                    model.SocialMedia.Add(new ModelSocialMedia()
                    {
                        IconClassName = sm.SocialMedia.IconClassName,
                        SocialMediaId = sm.SocialMedia.Id,
                        Url = sm.SocialMedia.Url,
                        ShortName = sm.SocialMedia.ShortName,
                        SocialMediaName = sm.SocialMedia.Name,
                    });
                }

                return PartialView("_TopBar", model);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ActionResult Footer()
        {
            try
            {
                List<Contact> contactRepoList = _contactRepository.GetAll().ToList();
                ModelFooter model = new ModelFooter()
                {
                    Email = contactRepoList[0].EmailAddress,
                    PhoneNumber = contactRepoList[0].PhoneNumber,
                    FaxNumber = contactRepoList[0].FaxNumber,
                    Address = contactRepoList[0].Address.AddressDetail
                };
                foreach (var sm in contactRepoList[0].ContactSocialMedias)
                {
                    model.SocialMedia.Add(new ModelSocialMedia()
                    {
                        IconClassName = sm.SocialMedia.IconClassName,
                        SocialMediaId = sm.SocialMedia.Id,
                        Url = sm.SocialMedia.Url,
                        ShortName = sm.SocialMedia.ShortName,
                        SocialMediaName = sm.SocialMedia.Name,
                    });
                }
                ExchangeRateService exchangeService = new ExchangeRateService();
                model.Currency= exchangeService.GetAllCurrency().Result as ExchangeRate ;

                return PartialView("_Footer", model);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}