using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UskudarDenetim.UI.Identity
{
    public class IdentityContext : IdentityDbContext<IDUser>
    {
        public IdentityContext() :base("UskudarDenetimIdentity")
        {

        }
  
        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
        // Other part of codes still same 
        // You don't need to add AppUser and AppRole 
        // since automatically added by inheriting form IdentityDbContext<AppUser>
    }
}