using System;
using System.Collections.Generic;
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
    }
}