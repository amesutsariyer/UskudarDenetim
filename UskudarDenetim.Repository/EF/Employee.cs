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
    
    public partial class Employee
    {
        public System.Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string Profession { get; set; }
        public string Title { get; set; }
        public Nullable<long> PhoneNumber { get; set; }
        public byte[] Photo { get; set; }
        public bool IsParent { get; set; }
        public string EmailAddress { get; set; }
    }
}
