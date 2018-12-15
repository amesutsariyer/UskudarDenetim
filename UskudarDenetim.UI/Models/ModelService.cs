using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UskudarDenetim.UI.Models
{
    public class ModelService
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [AllowHtml]
        [UIHint("tinymce_full")]
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int Order { get; set; }
        public bool  IsActive  { get; set; }
    }
}