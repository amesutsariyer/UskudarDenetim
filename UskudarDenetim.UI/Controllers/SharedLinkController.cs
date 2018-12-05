using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UskudarDenetim.Core.Extensions;
using UskudarDenetim.Repository;
using UskudarDenetim.Repository.EF;
using UskudarDenetim.Repository.Interface;
using UskudarDenetim.UI.Models;

namespace UskudarDenetim.UI.Controllers
{
    public class SharedLinkController : BaseController
    {
        private IGenericRepository<SharedLink> _sharedLinkRepository;
        public SharedLinkController()
        {
            _sharedLinkRepository = new GenericRepository<SharedLink>();
        }
        //[Authorize]
        public ActionResult SharedLinks()
        {
            return View(SharedLinkList());
        }
        public ActionResult _SharedLinks()
        {
            return PartialView("_SharedLinks", SharedLinkList());
        }
        public ActionResult SharedLinkDetail(string id)
        {
            var entity = _sharedLinkRepository.GetById(id.ConvertToGuid());
            ModelSharedLink model = new ModelSharedLink()
            {
                Id = entity.Id,
                Name = entity.Name,
                Url = entity.Url,
                //ImageUrl Burayı unutma db güncellenince gelecek burası
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult SharedLink(ModelSharedLink model)
        {
            SharedLink entity = new SharedLink()
            {
                Id = model.Id,
                Name = model.Name,
                Url = model.Url,
                //ImageUrl Burayı unutma db güncellenince gelecek burası
            };
            if (entity.Id != Guid.Empty)
            {
                _sharedLinkRepository.Update(entity);
            }
            else
            {
                _sharedLinkRepository.Create(entity);
            }
            return Json("Ok");
        }
        [HttpPost]
        public ActionResult DeleteSharedLink(string id)
        {
            return Json("Ok");
        }

        private List<ModelSharedLink> SharedLinkList()
        {
            var sharedLinkRepo = _sharedLinkRepository.GetAll().ToList();
            var model = sharedLinkRepo.Select(x => new ModelSharedLink()
            {
                Id = x.Id,
                ImageUrl = x.Url,
                Url = x.Url,
                Name = x.Name
            }).ToList();
            return model;
        }
    }
}