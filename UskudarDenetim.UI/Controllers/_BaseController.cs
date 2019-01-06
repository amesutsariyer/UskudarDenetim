using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UskudarDenetim.UI.Controllers
{
    public class BaseController : Controller
    {
        public static List<SelectListItem> GetCityDDL()
        {
            var cityList = new List<SelectListItem>();
            var item1 =  new SelectListItem()
            {
                Text = "Test",
                Value = 1.ToString()
            };
            cityList.Add(item1);
            return cityList;
        }
        public static List<SelectListItem> GetDistrictDDL()
        {
            var cityList = new List<SelectListItem>();
            var item1 = new SelectListItem()
            {
                Text = "Test",
                Value = 1.ToString()
            };
            cityList.Add(item1);
            return cityList;
        }

        public string UploadFile(HttpPostedFileBase file)
        {
    
                if (file != null && file.ContentLength > 0)
                {
                    // burada dilerseniz dosya tipine gore filtreleme yaparak sadece istediginiz dosya formatindaki dosyalari yukleyebilirsiniz
                    //if (file.ContentType == "image/jpeg" || file.ContentType == "image/jpg" || file.ContentType == "image/png" || file.ContentType == "image/gif")
                    //{
                    var fi = new FileInfo(file.FileName);
                    var fileName = Path.GetFileName(file.FileName);
                    fileName = Guid.NewGuid().ToString() + fi.Extension;
                    var path = Path.Combine(Server.MapPath("~/UploadFiles/"), fileName);
                    file.SaveAs(path);
                  return "/UploadFiles/"+fileName;
                //}
            }
            return null;
          
        }
        public string ReadFile(string path)
        {
       return     Path.GetFileName(path);
        }
    }
}