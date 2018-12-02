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
        private IGenericRepository<Address>_addressRepository ;
        public HomeController()
        {
            _addressRepository = new GenericRepository<Address>();
        }
        public ActionResult Index()
        {
            //var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            //var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<IDRole>>();

            //if (!roleManager.RoleExists("admin"))
            //    roleManager.Create(new IDRole("admin"));
            
            IQueryable<Address> a = _addressRepository.GetAll();
            var asd= a.ToList();
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