using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UskudarDenetim.Repository.EF;
using UskudarDenetim.UI.Models;

namespace UskudarDenetim.UI.Controllers
{
    public class SectorController : Controller
    {

        private Repository.Interface.GenericRepository<Sector> _sectorRepository;
        public SectorController()
        {
            _sectorRepository = new Repository.GenericRepository<Sector>();
        }
        // GET: Sector
        public ActionResult _SectorList()
        {
            return View(SectorList());
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            return View();

        }

        private List<ModelSector> SectorList()
        {
            return _sectorRepository.GetAll().Where(x => x.IsActive).OrderBy(x => x.Order).Select(x => new ModelSector()
            {
                Id=x.Id,
                Name=x.Name,
                Order=x.Order,
                IconClassName=x.IconClassName,
                IsActive=x.IsActive
            }).ToList();
        }
    }
}