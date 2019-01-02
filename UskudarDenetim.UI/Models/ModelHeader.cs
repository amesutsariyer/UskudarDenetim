using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UskudarDenetim.Repository.EF;

namespace UskudarDenetim.UI.Models
{
    public class ModelHeader
    {
        public List<ModelService> Services { get; set;}
        public List<ModelCatPI> CatPI { get; set;}
        public List<ModelPracticalInformation> PI { get; set;}
    }
}