using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UskudarDenetim.UI.Models
{
    public class ModelCircular
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Header { get; set; }
        [AllowHtml]
        [UIHint("tinymce_full")]
        [Display(Name = "About")]
        public string Description { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public bool IsDelete { get; set; }
        public string Title { get; set; }
        public Nullable<System.Guid> DocumentId { get; set; }
    }
}