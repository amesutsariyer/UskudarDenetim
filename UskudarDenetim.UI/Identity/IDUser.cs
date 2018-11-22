using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UskudarDenetim.UI.Identity
{
    public class IDUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}