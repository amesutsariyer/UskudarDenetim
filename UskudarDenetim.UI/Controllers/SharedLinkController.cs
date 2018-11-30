using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UskudarDenetim.UI.Models;

namespace UskudarDenetim.UI.Controllers
{
    public class SharedLinkController : BaseController
    {
        //[Authorize]
        public ActionResult SharedLinks()
        {
            return View(SharedLinkList());
        }
        public ActionResult _SharedLinks()
        {
            return PartialView("_SharedLinks",SharedLinkList());
        }
        public ActionResult SharedLinkDetail(string id) { return View(new ModelSharedLink()); }
        [HttpPost]
        public ActionResult SharedLink(ModelSharedLink model)
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
        public ActionResult DeleteSharedLink(string id)
        {
            return Json("Ok");
        }

        private List<ModelSharedLink> SharedLinkList()
        {
            var model = new List<ModelSharedLink>()
            {
                new ModelSharedLink()
                {
                    Id=Guid.NewGuid(),
                    Name="Gelir İdaresi Başkanlığı",
                    Url = "http://www.gib.gov.tr/",
                    ImageUrl=""
                },
                new ModelSharedLink()
                {
                       Id=Guid.NewGuid(),
                    Name="Sosyal Güvenlik Kurumu",
                    Url = "http://www.sgk.gov.tr/",
                    ImageUrl=""
                },
                 new ModelSharedLink()
                {
                    Id=Guid.NewGuid(),
                    Name="T.C Resmi Gazete",
                    Url = "http://www.resmigazete.gov.tr/default.aspx",
                    ImageUrl=""
                },
                new ModelSharedLink()
                {
                       Id=Guid.NewGuid(),
                    Name="Türmob",
                    Url = "https://www.turmob.org.tr/",
                    ImageUrl=""
                }
            };
            return model;
        }
    }
}