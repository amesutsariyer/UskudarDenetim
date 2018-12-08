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
    public class ServiceController : BaseController
    {
        private Repository.Interface.GenericRepository<Service> _serviceRepository;
       
        public ServiceController()
        {
            _serviceRepository = new Repository.GenericRepository<Service>();

        }
        public ActionResult GetServices()
        {
            return PartialView("_WhatWeDo", GetAllServices());
        }
        [HttpGet]
        public ActionResult ServiceDetail(string id)
        {
            var x = _serviceRepository.GetById(id.ConvertToGuid());

            return View(new ModelService() {
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                Id = x.Id,

            });
        }
        
        
        
        //[Authorize]
        [HttpGet]
        public ActionResult Services()
        {
            return View(GetAllServices());
        }
        [HttpPost]
        //[Authorize]
        public ActionResult DeleteService()
        {
            return Json("Ok");
        }
        [HttpPost]
        //[Authorize]
        public ActionResult Service(ModelService model)
        {
            if (model.Id != Guid.Empty)
            {
                return Json("ok");      //update
            }
            else
            {
                return Json("ok");      //update   //Add
            }
        }
        #region Private Methods
        public List<ModelService> GetAllServices()
        {
            var list = _serviceRepository.GetAll().ToList();
            var model = list.Select(x => new ModelService() {
                Name=x.Name,
               ImageUrl=x.ImageUrl,
               Description=x.Description,
               ShortDescription=x.ShortDescription,
               Id = x.Id,

            }).ToList();
            return model;
        }
        #endregion
    }
}