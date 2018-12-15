using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UskudarDenetim.Core.Extensions;
using UskudarDenetim.Repository.EF;
using UskudarDenetim.UI.Models;

namespace UskudarDenetim.UI.Controllers
{
    public class TeamMemberController : BaseController
    {
        private Repository.Interface.GenericRepository<Employee> _employeeRepository;
        private Repository.Interface.GenericRepository<Document> _documentRepository;

        public TeamMemberController()
        {
            _employeeRepository = new Repository.GenericRepository<Employee>();
            _documentRepository = new Repository.GenericRepository<Document>();
        }
        // GET: TeamMember
        public ActionResult Index()
        {
            var empList = _employeeRepository.GetAll().ToList();
            var model = empList.Where(x=>x.IsActive).OrderBy(x=>x.Order).Select(x => new ModelEmployee()
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
               // File = (HttpPostedFileBase)new MemoryPostedFile(x.Document.File)
            }).ToList();
          
            return View(model);
        }
        public ActionResult AllEmployee()
        {
            var empList = _employeeRepository.GetAll().Where(x => x.IsActive).OrderBy(x => x.Order).ToList();
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
            var empList = _employeeRepository.GetAll().Where(x => x.IsActive).OrderBy(x => x.Order).ToList();
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
                Order = employee.Order,
                ImgSrc = employee.Document.File.ConvertToSrc(),
                Document = new ModelDocument()
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
                        IsActive = true
                    };
                    _employeeRepository.Update(ent);
                    return RedirectToAction("Employees", "TeamMember");
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
                        Order = model.Order,
                        IsActive = true
                    };
                    _employeeRepository.Create(ent);
                    return RedirectToAction("Employees", "TeamMember");
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

    }
}