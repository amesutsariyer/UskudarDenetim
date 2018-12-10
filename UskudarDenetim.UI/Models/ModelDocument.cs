using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UskudarDenetim.UI.Models
{
    public class ModelDocument
    {
        public System.Guid Id { get; set; }
        public int Order { get; set; }
        public byte[] File { get; set; }
        public string Name { get; set; }
        public Nullable<long> Size { get; set; }
        public bool IsDeleted { get; set; }
    }
}