using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UskudarDenetim.Core.Helper;
using UskudarDenetim.Repository.EF;
using UskudarDenetim.Repository.Interface;
using UskudarDenetim.UI.Models;

namespace UskudarDenetim.UI.Controllers
{
    public class ContactController : BaseController
    {
        private Repository.Interface.GenericRepository<ContactUSFB> _contactRepository;
        public ContactController()
        {
            _contactRepository = new Repository.GenericRepository<ContactUSFB>();
        }
        // GET: ContactController
        [HttpGet]
        public ActionResult CreateContactUs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateContactUS(ModelContact model)
        {
            try
            {
                if (!model.ContactUS.Email.IsValidEmail())
                {
                    return Json(new { success = false, message = "Geçersiz Email Adresi" });
                }
                var contactUSFB = new ContactUSFB()
                {
                    CreatedDate = DateTime.Now,
                    IsRead = false,
                    Email = model.ContactUS.Email,
                    Id = Guid.NewGuid(),
                    Message = model.ContactUS.Message,
                    Name = model.ContactUS.Name,
                    PhoneNumber = model.ContactUS.PhoneNumber
                };
                _contactRepository.Create(contactUSFB);
                return Json(new { success = true, message = "Mesajınız Bize Ulaşmıştır :) En Kısa Sürede Size Geri Dönüş Yapacağız." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Sistemsel Bir Hata Oluştu" });
            }
        }

    }
}