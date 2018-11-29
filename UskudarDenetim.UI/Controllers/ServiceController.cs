using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UskudarDenetim.UI.Models;

namespace UskudarDenetim.UI.Controllers
{
    public class ServiceController : Controller
    {
      
        public ActionResult GetServices()
        {
            return PartialView("_WhatWeDo", GetAllServices());
        }
        public ActionResult ServiceDetail(string id)
        {
            return View();
        }
        
        
        
        //[Authorize]
        [HttpGet]
        public ActionResult Services()
        {
            return View(GetAllServices());
        }
        [HttpPost]
        //[Authorize]
        public ActionResult DeleteService()
        {
            return Json("Ok");
        }
        [HttpPost]
        //[Authorize]
        public ActionResult Service(ModelService model)
        {
            if (model.Id != Guid.Empty)
            {
                return Json("ok");      //update
            }
            else
            {
                return Json("ok");      //update   //Add
            }
        }
     
        
        
        #region Private Methods
        public List<ModelService> GetAllServices()
        {
            List<ModelService> model = new List<ModelService>()
             {
                 new ModelService()
                 {
                     Id = Guid.NewGuid(),
                     Name ="Hukuki Danışmanlık",
                     Description="Danışmanlık alanlarında profesyonel ve uzman avukatları ve akademik danışmanları ile hukuki hizmetlerinde etkili ve pratik çözümleriyle fark yaratmaktadır.",
                     IconClassName="fa fa-book",
                     ImageUrl="http://placehold.it/1170x592&text=Image"

                 },
                     new ModelService()
                 {
                     Id = Guid.NewGuid(),
                     Name ="YMM ve İç Denetim Hizmetleri",
                     Description="Şirketin faaliyetlerini geliştirmek ve onlara değer katmak amacıyla bağımsız ve objektif bir şekilde danışmanlık hizmetleri verilmektedir.",
                     ImageUrl="http://placehold.it/1170x592&text=Image",
                     IconClassName="fa fa-heartbeat",
                     },
                         new ModelService()
                     {
                     Id = Guid.NewGuid(),
                     Name ="Mali Danışmanlık",
                     Description="MHY Danışmanlık, sürekli değişen mali ve ekonomik şartların meydana getirdiği problemleri yakından takip ederek en doğru adımın en uygun zamanda atılmasını sağlamaktadır.",
                     ImageUrl="http://placehold.it/1170x592&text=Image",
                     IconClassName="fa fa-money",

             } };
            return model;
        }
        #endregion
    }
}