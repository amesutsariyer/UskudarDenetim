using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UskudarDenetim.UI.Models;

namespace UskudarDenetim.UI.Controllers
{
    public class ActivityAreaController : BaseController
    {
        public ActionResult GetActivityAreas()
        {
            return PartialView("_ActivityArea",GetAllActivity());
        }

        //Admin panel listeleme
        [HttpGet]
        //[Authorize]
        public ActionResult ActivityAreas()
        {
            return View(GetAllActivity());
        }
        //admin Panel Düzenleme 
        //[Authorize]
        [HttpPost]
        public ActionResult ActiviyArea(ModelActivityArea model)
        {
            if (model.Id !=Guid.Empty)
            {
                //update işlemi yap
            }
            else
            {
                //create İşlemi Yap
            }

            return Json("OK");
        }
     
        //[Authorize]
        [HttpPost]
        public ActionResult DeleteActivityArea(string id)
        {
            return Json("Ok");
        }
        #region PrivateMethods
        private List<ModelActivityArea> GetAllActivity()
        {
            return new List<ModelActivityArea>()
            {
                new ModelActivityArea()
                {
                    Id = Guid.NewGuid(),
                    Name ="Muhasebe",
                    Description = "Muhasebe Alanı Açıklaması",
                   IconClassName = "fa fa-edit"
                },
                new ModelActivityArea()
                {
                      Id = Guid.NewGuid(),
                    Name ="Kdv İadesi",
                    Description = "Kdv İadesi Açıklama",
                   IconClassName = "fa fa-edit"
                },
                 new ModelActivityArea()
                {
                    Id = Guid.NewGuid(),
                    Name ="Muhasebe",
                    Description = "Muhasebe Alanı Açıklaması",
                   IconClassName = "fa fa-edit"
                },
                new ModelActivityArea()
                {
                      Id = Guid.NewGuid(),
                    Name ="Kdv İadesi",
                    Description = "Kdv İadesi Açıklama",
                   IconClassName = "fa fa-edit"
                },
                 new ModelActivityArea()
                {
                    Id = Guid.NewGuid(),
                    Name ="Muhasebe",
                    Description = "Muhasebe Alanı Açıklaması",
                   IconClassName = "fa fa-edit"
                },
                new ModelActivityArea()
                {
                      Id = Guid.NewGuid(),
                    Name ="Kdv İadesi",
                    Description = "Kdv İadesi Açıklama",
                   IconClassName = "fa fa-edit"
                },
                new ModelActivityArea()
                {

                        Id = Guid.NewGuid(),
                    Name ="Şirket Açma",
                    Description = "Şirket Açma Açıklaması",
                   IconClassName = "fa fa-edit"
                },
                  new ModelActivityArea()
                {
                    Id = Guid.NewGuid(),
                    Name ="Ymmy",
                    Description = "Ymmy Açıklaması",
                   IconClassName = "fa fa-edit"
                }
            };
        }
        #endregion

    }
}