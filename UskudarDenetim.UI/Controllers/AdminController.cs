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
        public ActionResult AllEmployee()
        {
            var empList = _employeeRepository.GetAll().Where(x=>x.IsActive.Value).OrderBy(x=>x.Order).ToList();
            var model = empList.Select(x => new ModelEmployee()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                BirthDate = x.BirthDate.Value,
                Profession = x.Profession,
                Title = x.Title,
                PhoneNumber = x.PhoneNumber,
                Email = x.EmailAddress,
                ImgSrc = x.Document.File.ConvertToSrc(),
                File = (HttpPostedFileBase)new MemoryPostedFile(x.Document.File)

            }).ToList();
            return PartialView("_Employees", model);
        }
        public ActionResult Employees()
        {
            // return EmployeesModel 
            //Tüm çalışanlar Model ile gönderilmeli
            //IsPArent Patron burda göndercez her türlü
            var empList = _employeeRepository.GetAll().ToList();
            var model = empList.Select(x => new ModelEmployee()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                BirthDate = x.BirthDate.Value,
                Profession = x.Profession,
                Title = x.Title,
                PhoneNumber = x.PhoneNumber,
                Email = x.EmailAddress
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult UpdateEmployee(string id)
        {
            Guid idG = id.ConvertToGuid();
            var employee = _employeeRepository.GetById(idG);
            var model = new ModelEmployee()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate.Value.ConvertToUIDateFormat(),
                Profession = employee.Profession,
                Title = employee.Title,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.EmailAddress,
                Order = employee.Order.HasValue ? employee.Order.Value : 0,
                ImgSrc = employee.Document.File.ConvertToSrc(),
                Document =new ModelDocument()
                {
                    Id = employee.Document.Id
                },
                DocumentId = employee.Document.Id
            };

            return View("Employee", model);
        }
        [HttpPost]
        public ActionResult Employee(ModelEmployee model)
        {
            try
            {
                //if (model.File == null)
                //    return Json(new { success = false, message = "Resim Ekleyiniz" });
                var document = new Document();
                if (model.Id != null && model.Id != Guid.Empty)
                {
                    if (model.File != null)
                    {
                        document = new Document()
                        {
                            Id = Guid.NewGuid(),
                            IsDeleted = false,
                            File = model.File.ConvertToByteArray(),
                            Name = model.File.FileName,
                            Size = model.File.ContentLength,
                            Type = model.File.ContentType
                        };
                        _documentRepository.Create(document);
                    }
                    else
                    {
                        document.Id = model.DocumentId.Value;
                    }
                    var ent = new Employee()
                    {
                        Id = model.Id,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        BirthDate = model.BirthDate,
                        Profession = model.Profession,
                        Title = model.Title,
                        PhoneNumber = model.PhoneNumber,
                        EmailAddress = model.Email,
                        DocumentId = document.Id,
                        Order = model.Order,
                    };
                    _employeeRepository.Update(ent);
                    return RedirectToAction("Employees", "Admin");
                }
                else
                {
                    if (model.File == null)
                        return Json(new { success = false, message = "Resim Ekleyiniz" });

                    document = new Document()
                    {
                        Id = Guid.NewGuid(),
                        IsDeleted = false,
                        File = model.File.ConvertToByteArray(),
                        Name = model.File.FileName,
                        Size = model.File.ContentLength,
                        Type = model.File.ContentType
                    };
                    _documentRepository.Create(document);

                    var ent = new Employee()
                    {
                        Id = Guid.NewGuid(),
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        BirthDate = model.BirthDate,
                        Profession = model.Profession,
                        Title = model.Title,
                        PhoneNumber = model.PhoneNumber,
                        EmailAddress = model.Email,
                        DocumentId = document.Id,
                        Order = document.Order,
                    };
                    _employeeRepository.Create(ent);
                    return RedirectToAction("Employees", "Admin");
                }


            }
            catch (Exception)
            {
                return Json("false");

            }

        }

        [HttpPost]
        public ActionResult DeleteEmployee(string id)
        {
            try
            {
                var gId = id.ConvertToGuid();
                var entity = _employeeRepository.GetById(gId);
                entity.IsActive = false;
                _employeeRepository.Update(entity);
                return Json(new { success = true, message = "Başarıyla silinmiştir" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Beklenmeyen bir hata ile karşılaşıldı." });
            }

        }
        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View("Employee", new ModelEmployee());
        }

        #endregion
    
    }
}