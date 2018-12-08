using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
                    Position = model.Position
                };
                _hrRepository.Create(entity);
                //document.create()
                return Json(new { success = true, message = "Insan Kayakları Veritabanımıza Kayıt İşleminiz Tamamlanılmıştır." });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Kayıt İşlemi Esnasında Bir Hata İle Karşılaşıldı" });
            }
        }
        [Authorize]
        public ActionResult Applys()
        {
            //GetAll()
            var model = new List<ModelHRApplyForm>() { };
            return View(model);
        }
        [Authorize]
        public ActionResult ApplyDetail(string id)
        {
            //GetApplyByID
            var model = new ModelHRApplyForm() { };
            return View(model);
        }
        [Authorize]
        public ActionResult DeleteApply()
        {
            return Json("ok");
        }
    }
}