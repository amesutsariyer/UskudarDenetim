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
    public class CircularController : BaseController
    {
        // GET: Blog  CircularList

        private Repository.Interface.GenericRepository<Circular> _circularRepository;
        public CircularController()
        {
            _circularRepository = new Repository.GenericRepository<Circular>();
        }

        public ActionResult Index()
        {
            var model = GetAllCircular();
            return View(model);
        }
        public ActionResult GetCircular()
        {
            return PartialView("_Circular",GetAllCircular().Take(3).ToList());
        }
        public ActionResult Detail(string id)
        {
            var gId = id.ConvertToGuid();
            var entity = _circularRepository.GetById(gId);
            var viewData = new ModelCircular()
            {
                Id = entity.Id,
                Name = entity.Header,
                CreatedDate = entity.CreatedDate,
                Description = entity.Description,
                Title = entity.Title,
                Header = entity.Header,
                DocumentId = entity.DocumentId,
                IsDelete = entity.IsDelete,
            };
            return View(viewData);
        }
        [Authorize]
        public ActionResult CircularList()
        {
            return View(GetAllCircular());
        }
        [Authorize]
        public ActionResult Update(string id)
        {
            var gId = id.ConvertToGuid();
            var entity = _circularRepository.GetById(gId);
            var viewData = new ModelCircular()
            {
                Id = entity.Id,
                Name = entity.Header,
                CreatedDate = entity.CreatedDate,
                Description = entity.Description,
                Title = entity.Title,
                Header = entity.Header,
                DocumentId = entity.DocumentId,
                IsDelete = entity.IsDelete,
            };
            return View("AddOrUpdate", viewData);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View("AddOrUpdate");
        }
        [HttpPost]
        [Authorize]
        public ActionResult Delete(string id)
        {
            try
            {
                var gId = id.ConvertToGuid();
                var entity = _circularRepository.GetById(gId);
                entity.IsDelete = true;
                _circularRepository.Update(entity);
                return Json(new { success = true, message = "Başarıyla silinmiştir" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Beklenmeyen bir hata ile karşılaşıldı." });
            }
        }
        [HttpPost]
        [Authorize]
        public ActionResult CreateOrUpdate(ModelCircular model)
        {
            try
            {
                Circular ent = new Circular()
                {
                    Id = model.Id,
                    Name = model.Header,
                    CreatedDate = DateTime.Now,
                    Description = model.Description,
                    Title = model.Title,
                    Header = model.Header,
                    DocumentId = model.DocumentId,
                    IsDelete = model.IsDelete
                };

                if (model.Id == Guid.Empty || model.Id == null)
                {
                    ent.Id = Guid.NewGuid();
                    ent.IsDelete = false;
                    _circularRepository.Create(ent);
                    return Json(new { success = true, message = "Kayıt İşlemi Başarılı." });

                }
                else
                {
                    _circularRepository.Update(ent);
                    return Json(new { success = true, message = "Güncelleme İşlemi Başarılı." });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Beklenmedik Bir Hata İle Karşılaşıldı" });
            }
        }

        private List<ModelCircular> GetAllCircular()
        {
            var a = _circularRepository.GetAll().ToList();
            return _circularRepository.GetAll().Where(x => x.IsDelete == false).OrderByDescending(x => x.CreatedDate).Select(x => new ModelCircular()
            {

                Id = x.Id,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Title = x.Title,
                DocumentId = x.DocumentId,
                Header = x.Header,
                IsDelete = x.IsDelete,
                Name = x.Name
            }).ToList();

        }
    }
}