using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UskudarDenetim.UI.Models
{
    public class ModelAppointmentRequest
    {
        public System.Guid Id { get; set; }
        public string RequestNumber { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> AppointmentDate { get; set; }
        public string PreferPlace { get; set; }
        public string Description { get; set; }
    }
}