using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UskudarDenetim.Core.Extensions
{
   public static class UDExtension
    {
        public static Guid ConvertToGuid(this string id)
        {
            try
            {
                Guid parsedGuid = Guid.Parse(id);
                return parsedGuid;
            }
            catch (ArgumentNullException )
            {
                throw new ArgumentNullException("The string to be parsed is null.");
            }
            catch (FormatException )
            {
                throw new FormatException("Bad Format ");  
            }

        }
    }
}
