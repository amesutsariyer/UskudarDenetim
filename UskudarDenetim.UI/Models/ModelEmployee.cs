using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UskudarDenetim.UI.Models
{
    public class ModelEmployee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Profession { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] Photo { get; set; }
        public HttpPostedFileBase File { get; set; }
        public bool IsParent{ get; set; }
        public string Email { get; set; }
        public string About { get; set; }
        public string Description { get; set; }
        public Nullable<System.Guid> DocumentId { get; set; }
        public string ImgSrc { get; set; }
        public ModelDocument Document { get; set; }
    }
}