using MailReceiver.Base.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UskudarDenetim.UI.Models
{
    public class ModelMail : MailRequest
    {
        public string ToArrayString { get; set; }
    }
}