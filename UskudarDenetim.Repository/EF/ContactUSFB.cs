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
    
    public partial class ContactUSFB
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<bool> IsRead { get; set; }
        public string Message { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}
