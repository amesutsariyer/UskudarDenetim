using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UskudarDenetim.UI.Models;

namespace UskudarDenetim.UI.Controllers
{
    public class HRController : Controller
    {
        // GET: HR
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateApplyForm(ModelHRApplyForm model)
        {
            return Json("Ok");
        }
    }
}