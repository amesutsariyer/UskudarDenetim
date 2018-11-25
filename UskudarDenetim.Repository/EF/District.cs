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
    
    public partial class District
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public District()
        {
            this.Addresses = new HashSet<Address>();
        }
    
        public int Id { get; set; }
        public Nullable<int> CityId { get; set; }
        public string Name { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<double> Northeast_lat { get; set; }
        public Nullable<double> Northeast_lng { get; set; }
        public Nullable<double> Southwest_lat { get; set; }
        public Nullable<double> Southwest_lng { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual City City { get; set; }
    }
}