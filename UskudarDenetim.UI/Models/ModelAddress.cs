using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UskudarDenetim.UI.Models
{
    public class ModelAddress
    {

        public System.Guid Id { get; set; }
        public string Header { get; set; }
        public string Name { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string AddressDetail { get; set; }

        public List<SelectListItem> CitySelectList { get; set; }
        public List<SelectListItem> DistrictSelectList { get; set; }

        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public string CityName { get; set; }
        public string DistrictName { get; set; }


    }
}