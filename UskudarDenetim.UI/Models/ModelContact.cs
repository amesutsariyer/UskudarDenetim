using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UskudarDenetim.UI.Models
{
    public class ModelContact
    {
        public ModelContact()
        {
            ContactSocialMedias = new List<ModelSocialMedia>();
            Address = new ModelAddress();
        }

        public System.Guid Id { get; set; }
        public Nullable<System.Guid> AddressId { get; set; }
        public string PhoneNumber { get; set; }
        public string LocalePhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public string EmailAddress2 { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public  ModelAddress Address { get; set; }
        public virtual List<ModelSocialMedia> ContactSocialMedias { get; set; }
    }
}