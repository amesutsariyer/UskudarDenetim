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
    public class HRController : BaseController
    {
        private Repository.Interface.GenericRepository<HRApplyForm> _hrRepository;
        public HRController()
        {
            _hrRepository = new Repository.GenericRepository<HRApplyForm>();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateApplyForm(ModelHRApplyForm model)
        {
            try
            {
                if (model.File.ContentLength !=0)
                {
                    var path = UploadFile(model.File);
                    var entity = new HRApplyForm()
                    {
                        Id = Guid.NewGuid(),
                        Name = model.Name,
                        Address = model.Address,
                        Birthdate = model.Birthdate,
                        CityName = model.CityName,
                        Email = model.Email,
                        Surname = model.Surname,
                        Gender = model.Gender,
                        EducationStatus = model.EducationStatus,
                        ExternalPhoneNumber = model.ExternalPhoneNumber,
                        IdentityNumber = model.IdentityNumber,
                        Note = model.Note,
                        PhoneNumber = model.Position,
                        Position = model.Position,
                        Document = path
                    };
                    _hrRepository.Create(entity);
                    //document.create()
                    return Json(new { success = true, message = "Insan Kayakları Veritabanımıza Kayıt İşleminiz Tamamlanılmıştır." });
                }
                return      Json(new { success = false, message = "Dokuman Eklenirken Bir Sorunla Karşılaşıldı." });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Lütfen Dokuman Seçiniz" });
            }
        }
        [Authorize]
        public ActionResult Applys()
        {
         var model =   _hrRepository.GetAll().Select(x=> new ModelHRApplyForm() {
                Id =x.Id,
                Name = x.Name,
                Address = x.Address,
                Birthdate = x.Birthdate,
                CityName = x.CityName,
                Email = x.Email,
                Surname = x.Surname,
                Gender = x.Gender,
                EducationStatus = x.EducationStatus,
                ExternalPhoneNumber = x.ExternalPhoneNumber,
                IdentityNumber = x.IdentityNumber,
                Note = x.Note,
                PhoneNumber = x.Position,
                Position = x.Position
            }).ToList();
            return View(model);
        }
        [Authorize]
        public ActionResult ApplyDetail(string id)
        {
            //GetApplyByID
            var model = _hrRepository.GetById(id.ConvertToGuid());
            var ent = new ModelHRApplyForm() {
                Id =model.Id,
                Name = model.Name,
                Address = model.Address,
                Birthdate = model.Birthdate,
                CityName = model.CityName,
                Email = model.Email,
                Surname = model.Surname,
                Gender = model.Gender,
                EducationStatus = model.EducationStatus,
                ExternalPhoneNumber = model.ExternalPhoneNumber,
                IdentityNumber = model.IdentityNumber,
                Note = model.Note,
                PhoneNumber = model.Position,
                Position = model.Position
            };
            return View(ent);
        }
        [Authorize]
        public ActionResult DeleteApply(string id)
        {
            var entity = _hrRepository.GetById(id.ConvertToGuid());
            _hrRepository.Delete(entity);
            return Json(new { Success = true, Message = "Silme İşlemi Başarılı." });
        }
    }
}