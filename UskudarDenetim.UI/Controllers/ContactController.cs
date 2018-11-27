using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UskudarDenetim.UI.Models;

namespace UskudarDenetim.UI.Controllers
{
    public class ContactController : BaseController
    {
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
                model.ContactUS.CreatedDate = DateTime.Now;
                model.ContactUS.IsRead = false;
                return Json("Ok");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}