﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UskudarDenetim.Core.Extensions;
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
            try
            {
                if (model.Id != Guid.Empty)
                {
                    _activityAreaRepository.Update(new ActivityArea()
                    {

                        Id = model.Id,
                        Description = model.Description,
                        IconName = model.IconClassName,
                        Name = model.Name
                    });
                }
                else
                {
                    _activityAreaRepository.Create(new ActivityArea()
                    {
                        Id = Guid.NewGuid(),
                        Description = model.Description,
                        IconName = model.IconClassName,
                        Name = model.Name
                    });
                }

                return Json(new { Success = true, Message = "Kayıt İşlemi Başarılı" });
            }
            catch (Exception)
            {
                return Json(new { Success = false, Message = "Kayıt İşlemi Sırasında Bir Hata Oluştu" });
            }
        
        }
     
        //[Authorize]
        [HttpPost]
        public ActionResult DeleteActivityArea(string id)
        {
            try
            {
                var ent = _activityAreaRepository.GetById(id.ConvertToGuid());
                _activityAreaRepository.Delete(ent);
                return Json(new { Success = true, Message = "Silme İşlemi Başarılı" });
            }
            catch (Exception)
            {
                return Json(new { Success = false, Message = "Silme İşlemi Sırasında Bir Hata Oluştu" });
            }
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