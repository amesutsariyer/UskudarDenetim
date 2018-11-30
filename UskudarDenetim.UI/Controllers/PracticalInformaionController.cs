using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UskudarDenetim.UI.Models;

namespace UskudarDenetim.UI.Controllers
{
    public class PracticalInformaionController : BaseController
    {
        //[Authorize]
        public ActionResult PracticalInformations()
        {
            return View(PracticalInformationList());
        }
        public ActionResult _PracticalInformations()
        {
            return PartialView("_PracticalInformations", PracticalInformationList());
        }
        public ActionResult PracticalInformationDetail(string id) { return View(new ModelPracticalInformation()); }
        [HttpPost]
        public ActionResult PracticalInformation(ModelPracticalInformation model)
        {
            if (model.Id != Guid.Empty)
            {

            }
            else
            {

            }
            return Json("Ok");
        }
        [HttpPost]
        public ActionResult DeletePracticalInformation(string id)
        {
            return Json("Ok");
        }

        private List<ModelPracticalInformation> PracticalInformationList()
        {
            var model = new List<ModelPracticalInformation>()
            {
                new ModelPracticalInformation()
                {
                    Id=Guid.NewGuid(),
                    Name="Gelir İdaresi Başkanlığı",

                },
                new ModelPracticalInformation()
                {
                       Id=Guid.NewGuid(),
                    Name="Sosyal Güvenlik Kurumu",

                },
                 new ModelPracticalInformation()
                {
                    Id=Guid.NewGuid(),
                    Name="T.C Resmi Gazete",

                },
                new ModelPracticalInformation()
                {
                       Id=Guid.NewGuid(),
                    Name="Türmob",
                               }
            };
            return model;
        }
    }
}