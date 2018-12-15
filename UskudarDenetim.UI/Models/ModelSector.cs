using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UskudarDenetim.UI.Models
{
    public class ModelSector
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }
        public string IconClassName { get; set; }
    }
}