using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UskudarDenetim.Core.Extensions;
using UskudarDenetim.Repository.EF;
using UskudarDenetim.UI.Models;

namespace UskudarDenetim.UI.Controllers
{
    public class PracticalInformationsController : BaseController
    {
        private Repository.Interface.GenericRepository<PracticalInformation> _practicalAreaRepository;
        private Repository.Interface.GenericRepository<BoardOfDirector> _directorRepository;
        private Repository.Interface.GenericRepository<Sector> _sectorRepository;
        public PracticalInformationsController()
        {
            _practicalAreaRepository = new Repository.GenericRepository<PracticalInformation>();
            _directorRepository = new Repository.GenericRepository<BoardOfDirector>();
            _sectorRepository = new Repository.GenericRepository<Sector>();
        }
        public ActionResult Index()
        {
            return View(PracticalInformationList());
        }
        //[Authorize]
        public ActionResult PracticalInformations()
        {
            return View(PracticalInformationList());
        }
        public ActionResult _PracticalInformations()
        {
            int countInformation = Convert.ToInt32(ConfigurationManager.AppSettings["PracticalInformationCount"]);
            var director = _directorRepository.GetAll().First();
            var sector = _sectorRepository.GetAll().Where(x => x.IsActive).OrderBy(x => x.Order).Select(x => new ModelSector()
            {
                Id = x.Id,
                Name = x.Name,
                Order = x.Order,
                IconClassName = x.IconClassName,
                IsActive = x.IsActive
            }).ToList();
            ModelPracticalInformationViewModel model = new ModelPracticalInformationViewModel
            {

                PracticalInformationList = PracticalInformationList().Take(countInformation).ToList(),
                Sector = sector,
                Director = new ModelEmployee()
                {
                    FirstName = director.Name,
                    LastName = director.Surname,
                    Title = director.Title,
                    Profession = director.About,
                    About = director.About
                }
            };
            return PartialView("_PracticalInformations", model);
        }
        public ActionResult Detail(string id)
        {
            var model = _practicalAreaRepository.GetById(id.ConvertToGuid());
            return View(new ModelPracticalInformation() { Description = model.Description, Detail = model.LongDescription, Name = model.Name });
        }
        [HttpPost]
        public ActionResult PracticalInformation(ModelPracticalInformation model)
        {
            if (model.Id != Guid.Empty)
            {

            }
            else
            {

            }
            return Json("Ok");
        }
        [HttpPost]


        //[Authorize]

        public ActionResult Updates(string id)
        {
            var gId = id.ConvertToGuid();
            var entity = _practicalAreaRepository.GetById(gId);
            var viewData = new ModelPracticalInformation()
            {
                Id = entity.Id,
                CreatedDate = entity.CreatedDate,
                Description = entity.Description,
                Detail = entity.LongDescription,
                IsActive = entity.IsActive,
                Name = entity.Name,
                Order = entity.Order
            };
            return View("AddOrUpdate", viewData);
        }
        //[Authorize]
        public ActionResult Create(string id = null)
        {
            if (id != null)
            {
                var gId = id.ConvertToGuid();
                var entity = _practicalAreaRepository.GetById(gId);
                var viewData = new ModelPracticalInformation()
                {
                    Id = entity.Id,
                    CreatedDate = entity.CreatedDate,
                    Description = entity.Description,
                    Detail = entity.LongDescription,
                    IsActive = entity.IsActive,
                    Name = entity.Name,
                    Order = entity.Order
                };
                return View("AddOrUpdate", viewData);
            }
            return View("AddOrUpdate", new ModelPracticalInformation());
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                var gId = id.ConvertToGuid();
                var entity = _practicalAreaRepository.GetById(gId);
                entity.IsActive = false;
                _practicalAreaRepository.Update(entity);
                return Json(new { success = true, message = "Başarıyla silinmiştir" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Beklenmeyen bir hata ile karşılaşıldı." });
            }
        }
        [HttpPost]
        public ActionResult CreateOrUpdate(ModelPracticalInformation model)
        {
            try
            {
                PracticalInformation ent;

                if (model.Id == Guid.Empty || model.Id == null)
                {
                    ent = new PracticalInformation()
                    {
                        Id = Guid.NewGuid(),
                        Name = model.Name,
                        CreatedDate = DateTime.Now,
                        Description = model.Description,
                        IsActive = true,
                        Order = 0,
                        LongDescription = model.Detail
                    };
                    _practicalAreaRepository.Create(ent);
                    return Json(new { success = true, message = "Kayıt İşlemi Başarılı." });

                }
                else
                {
                    ent = new PracticalInformation()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        CreatedDate = model.CreatedDate,
                        Description = model.Description,
                        IsActive = true,
                        Order = model.Order,
                        LongDescription = model.Detail
                    };
                    _practicalAreaRepository.Update(ent);
                    return Json(new { success = true, message = "Güncelleme İşlemi Başarılı." });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Beklenmedik Bir Hata İle Karşılaşıldı" });
            }
        }

        private List<ModelPracticalInformation> PracticalInformationList()
        {
            var ent = _practicalAreaRepository.GetAll().Where(x => x.IsActive).ToList();
            var piModel = ent.Select(x => new ModelPracticalInformation()
            {
                Id = x.Id,
                Detail = x.LongDescription,
                Name = x.Name,
                Description = x.Description,
                IsActive = x.IsActive,
                CreatedDate = x.CreatedDate,
                Order = x.Order
            }).ToList();
            return piModel;
        }
    }
}