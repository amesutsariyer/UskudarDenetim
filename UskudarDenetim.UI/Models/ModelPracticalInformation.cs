using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UskudarDenetim.UI.Models
{
    public class ModelPracticalInformation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [AllowHtml]
        [UIHint("tinymce_full")]
        public string Detail { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }

    }
}