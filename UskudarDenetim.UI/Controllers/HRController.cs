﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UskudarDenetim.UI.Models;

namespace UskudarDenetim.UI.Controllers
{
    public class HRController : BaseController
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