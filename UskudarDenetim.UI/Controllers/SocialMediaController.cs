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
    public class SocialMediaController : BaseController
    {
        private Repository.Interface.GenericRepository<SocialMedia> _socialMediaRepository;
        public SocialMediaController()
        {
            _socialMediaRepository = new Repository.GenericRepository<SocialMedia>();
        }
        [HttpPost]
        [Authorize]
        public ActionResult Delete(string id)
        {
            try
            {
                var ent = _socialMediaRepository.GetById(id.ConvertToGuid());
                _socialMediaRepository.Delete(ent);
                return Json(new { Success = true, Message = "Silme İşlemi Başarılı" });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = "Silme İşlemi Sırasında Bir Hata Oluştu" });
            }
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddOrUpdate(ModelSocialMedia model)
        {
            try
            {
                SocialMedia ent;
                if (model.SocialMediaId == Guid.Empty || model.SocialMediaId == null)
                {
                    ent = new SocialMedia()
                    {
                        Id = Guid.NewGuid(),
                        Name = model.SocialMediaName,
                        Url =model.Url,
                        IconClassName =model.IconClassName
                    };
                    _socialMediaRepository.Create(ent);
                    return Json(new { Success = true, Message = "Kayıt İşlemi Başarılı." });
                }
                else
                {
                    ent = new SocialMedia()
                    {
                        Id = model.SocialMediaId,
                        Name = model.SocialMediaName,
                        Url = model.Url,
                        IconClassName = model.IconClassName
                    };
                    _socialMediaRepository.Update(ent);
                    return Json(new { Success = true, Message = "Güncelleme İşlemi Başarılı." });
                }
            }
            catch (Exception)
            {
                return Json(new { Success = false, Message = "Beklenmedik Bir Hata İle Karşılaşıldı" });
            }
        }
    }
}