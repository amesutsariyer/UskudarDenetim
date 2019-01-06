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
        private Repository.Interface.GenericRepository<SharedLink> _sharedLinkRepository;
        public SharedLinkController()
        {
            _sharedLinkRepository = new Repository.GenericRepository<SharedLink>();
        }
        [Authorize]
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
                ImageUrl =entity.ImageUrl
                //ImageUrl Burayı unutma db güncellenince gelecek burası
            };
            return View(model);
        }
        public ActionResult AddSharedLink(string id)
        {
         
            if (!string.IsNullOrEmpty(id))
            {
                var gid = id.ConvertToGuid();
                var model = _sharedLinkRepository.GetById(gid);
                return View("AddSharedLink", new ModelSharedLink() {
                    Id = model.Id,
                    ImageUrl = model.ImageUrl,
                    Name = model.Name,
                    Url=model.Url
                });
            }
            else
            {
                return View("AddSharedLink", new ModelSharedLink());
            }
        }
        [HttpPost]
        public ActionResult SharedLink(ModelSharedLink model)
        {

            var filePath = UploadFile(model.FileOne);
            SharedLink entity = new SharedLink()
            {
                Id = model.Id,
                Name = model.Name,
                Url = model.Url,
                ImageUrl = filePath,
                //ImageUrl Burayı unutma db güncellenince gelecek burası
            };
            if (entity.Id != Guid.Empty)
            {
                _sharedLinkRepository.Update(entity);
            }
            else
            {
                entity.Id = Guid.NewGuid();
                _sharedLinkRepository.Create(entity);
            }
            return RedirectToAction("SharedLinks","SharedLink");
        }
        [HttpPost]
        [Authorize]
        public ActionResult DeleteSharedLink(string id)
        {
            try
            {
                var ent = _sharedLinkRepository.GetById(id.ConvertToGuid());
                _sharedLinkRepository.Delete(ent);
                return Json(new { Success = true, Message = "Silme İşlemi Başarılı" });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = "Silme İşlemi Sırasında Bir Hata Oluştu" });
            }
        }

        private List<ModelSharedLink> SharedLinkList()
        {
            var sharedLinkRepo = _sharedLinkRepository.GetAll().ToList();
            var model = sharedLinkRepo.Select(x => new ModelSharedLink()
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Url = x.Url,
                Name = x.Name
            }).ToList();
            return model;
        }
    }
}