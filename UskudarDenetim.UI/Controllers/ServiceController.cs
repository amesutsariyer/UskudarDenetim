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
        public ActionResult Index()
        {
            return View(GetAllServices());
        }
        public ActionResult GetServices()
        {
            return PartialView("_WhatWeDo", GetAllServices().Take(3).ToList());
        }
        [HttpGet]
        public ActionResult ServiceDetail(string id)
        {
            var x = _serviceRepository.GetById(id.ConvertToGuid());

            return View(new ModelService()
            {
                Name = x.Name,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                Id = x.Id,
            });
        }

        [Authorize]
        [HttpGet]
        public ActionResult Services()
        {
            return View(GetAllServices());
        }
        [HttpPost]
        [Authorize]
        public ActionResult DeleteService(string id)
        {
            try
            {
                Guid gId = id.ConvertToGuid();
                var entity = _serviceRepository.GetById(gId);
                entity.IsActive = false;
                _serviceRepository.Update(entity);
                return Json(new { success = true, message = "Başarılı Bir Şekilde Kaydedildi." });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Hata Oluştu." });
            }
        }
        [HttpPost]
        [Authorize]
        public ActionResult Service(ModelService model)
        {
            Service service = new Service();
            if (model.Id != Guid.Empty)
            {
                service.Id = model.Id;
                service.IsActive = true;
                service.Name = model.Name;
                service.ShortDescription = model.ShortDescription;
                service.Order = model.Order;
                service.Description = model.Description;

                _serviceRepository.Update(service);
                return Json(new { success = true, message = "Kayıt İşlemi Başarıyla Tamamlanılmıştır." });
                //update
            }
            else
            {
                service.Id = Guid.NewGuid();
                service.IsActive = true;
                service.Name = model.Name;
                service.ShortDescription = model.ShortDescription;
                service.Order = model.Order;
                service.Description = model.Description;

                _serviceRepository.Create(service);
                return Json(new { success = true, message = "Kayıt İşlemi Başarıyla Tamamlanılmıştır." });
            }
        }
        [Authorize]
        public ActionResult Update(string id)
        {
            var gId = id.ConvertToGuid();
            var ent = _serviceRepository.GetById(gId);
            var model = new ModelService()
            {
                Id = ent.Id,
                IsActive = ent.IsActive,
                Description = ent.Description,
                Name = ent.Name,
                Order = ent.Order,
                ShortDescription = ent.ShortDescription
            };
            return View("AddOrUpdate", model);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View("AddOrUpdate", new ModelService());
        }
        public ActionResult Detail(string id)
        {
            var gId = id.ConvertToGuid();
            var entity = _serviceRepository.GetById(gId);
            var viewData = new ModelService()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
            };
            return View(viewData);
        }
        [HttpPost]
        [Authorize]
        public ActionResult CreateOrUpdate(ModelService model)
        {
            try
            {
                Service entity;
                if (model.Id ==Guid.Empty)
                {
                    entity = new Service()
                    {
                        Id =Guid.NewGuid(),
                        IsActive = true,
                        Description = model.Description,
                        Name = model.Name,
                        Order = model.Order,
                        ShortDescription = model.ShortDescription
                    };
                    _serviceRepository.Create(entity);
                }
                else
                {
                    entity = new Service()
                    {
                        Id = model.Id,
                        IsActive = true,
                        Description = model.Description,
                        Name = model.Name,
                        Order = model.Order,
                        ShortDescription = model.ShortDescription
                    };
                    _serviceRepository.Update(entity);
                }
                return Json(new { success = true, message = "Başarılı Bir Şekilde Kaydedildi." });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Hata İle Karşılaşıldı" });
            }
        }

        #region Private Methods
        public List<ModelService> GetAllServices()
        {
            var list = _serviceRepository.GetAll().ToList();
            var model = list.Where(x => x.IsActive).OrderBy(x => x.Order).Select(x => new ModelService()
            {
                Name = x.Name,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                Id = x.Id,
            }).ToList();
            return model;
        }
        #endregion
    }
}