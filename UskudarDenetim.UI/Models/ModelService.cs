using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UskudarDenetim.UI.Models
{
    public class ModelService
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconClassName { get; set; }
        public byte[] Image { get; set; }
        public string ImageUrl { get; set; }

    }
}