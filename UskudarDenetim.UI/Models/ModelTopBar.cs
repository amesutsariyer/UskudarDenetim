using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UskudarDenetim.UI.Models
{
    public class ModelTopBar
    {
        public ModelTopBar()
        {
            SocialMedia = new List<ModelSocialMedia>();
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<ModelSocialMedia> SocialMedia{ get; set; }
    }
}