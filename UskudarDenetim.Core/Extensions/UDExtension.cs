using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("The string to be parsed is null.");
            }
            catch (FormatException)
            {
                throw new FormatException("Bad Format ");
            }

        }
        public static DateTime ConvertToUIDateFormat(this DateTime dateTime)
        {
            var constr   = dateTime.ToString("yyyy-MM-dd");
            return Convert.ToDateTime(constr);
        }
        public static string ConvertToSrc(this byte[] bArray)
        {
            try
            {
                var base64 = Convert.ToBase64String(bArray);
                return string.Format("data:image/gif;base64,{0}", base64);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static byte[] ConvertToByteArray(this HttpPostedFileBase file)
        {
            try
            {
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    fileData = binaryReader.ReadBytes(file.ContentLength);
                }
                return fileData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
         
        }
    }
}
