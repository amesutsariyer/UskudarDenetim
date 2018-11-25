using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UskudarDenetim.UI.Models
{
    public class ModelSocialMedia
    {
        public System.Guid SocialMediaId { get; set; }
        public string SocialMediaName { get; set; }
        public string ShortName { get; set; }
        public string Url { get; set; }
        public string IconClassName { get; set; }
    }
}