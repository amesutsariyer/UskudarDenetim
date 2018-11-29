using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UskudarDenetim.UI.Models
{
    public class ModelHRApplyForm
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public long IdentityNumber { get; set; }
        public string Gender { get; set; }
        public System.DateTime Birthdate { get; set; }
        public string CityName { get; set; }
        public string EducationStatus { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ExternalPhoneNumber { get; set; }
        public string Position { get; set; }
        public string Note { get; set; }
    }
}