using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UskudarDenetim.Repository.EF;
using UskudarDenetim.UI.Models;

namespace UskudarDenetim.UI.Controllers
{
    public class ActivityAreaController : BaseController
    {
        private Repository.Interface.GenericRepository<ActivityArea> _activityAreaRepository;
        public ActivityAreaController()
        {
            _activityAreaRepository = new Repository.GenericRepository<ActivityArea>();
        }
        public ActionResult GetActivityAreas()
        {
            return PartialView("_ActivityArea",GetAllActivity());
        }

        //Admin panel listeleme
        [HttpGet]
        //[Authorize]
        public ActionResult ActivityAreas()
        {
            return View(GetAllActivity());
        }
        //admin Panel Düzenleme 
        //[Authorize]
        [HttpPost]
        public ActionResult ActiviyArea(ModelActivityArea model)
        {
            if (model.Id !=Guid.Empty)
            {
                //update işlemi yap
            }
            else
            {
                //create İşlemi Yap
            }

            return Json("OK");
        }
     
        //[Authorize]
        [HttpPost]
        public ActionResult DeleteActivityArea(string id)
        {
            return Json("Ok");
        }
        #region PrivateMethods
        private List<ModelActivityArea> GetAllActivity()
        {
            var listEntity = _activityAreaRepository.GetAll().ToList();
            return listEntity.Select(x => new ModelActivityArea() {
                Id = x.Id,
                Description=x.Description,
               IconClassName=x.IconName,
               Name=x.Name

            }).ToList();
        }
        #endregion

    }
}