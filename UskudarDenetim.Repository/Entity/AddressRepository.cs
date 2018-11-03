using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UskudarDenetim.Repository.EF;

namespace UskudarDenetim.Repository.Entity
{
   public class AddressRepository
    {
        public List<Address> GetAddresses()
        {
            UskudarDenetimEntities context = new UskudarDenetimEntities();
            return context.Addresses.ToList();

        }

    }
}
