using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UskudarDenetim.UI.Identity
{
    public class IDRole : IdentityRole
    {

        public IDRole() : base() { }
        public IDRole(string name) : base(name) { }
    }
}