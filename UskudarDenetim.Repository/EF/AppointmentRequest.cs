//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UskudarDenetim.Repository.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class AppointmentRequest
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
