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
        //[Authorize]
        public ActionResult PracticalInformations()
        {
            return View(PracticalInformationList());
        }
        public ActionResult _PracticalInformations()
        {
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
                PracticalInformationList = PracticalInformationList(),
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
        public ActionResult PracticalInformationDetail(string id)
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
        public ActionResult DeletePracticalInformation(string id)
        {
            return Json("Ok");
        }

        private List<ModelPracticalInformation> PracticalInformationList()
        {
            var ent = _practicalAreaRepository.GetAll().ToList();
            var piModel = ent.Select(x => new ModelPracticalInformation()
            {
                Id = x.Id,
                Detail = x.LongDescription,
                Name = x.Name,
                Description = x.Description
            }).ToList();
            return piModel;
        }
    }
}