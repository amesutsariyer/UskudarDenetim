using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UskudarDenetim.UI.Models
{
    public class ModelPracticalInformationViewModel
    {
        public List<ModelSector> Sector { get; set; }
        public ModelEmployee Director { get; set; }
        public List<ModelPracticalInformation> PracticalInformationList { get; set; }
    }
}