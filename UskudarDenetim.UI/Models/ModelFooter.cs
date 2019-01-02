using ExhangeRateService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UskudarDenetim.UI.Models
{
    public class ModelFooter
    {
        public ModelFooter()
        {
            SocialMedia = new List<ModelSocialMedia>();
        }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string EmailSubs { get; set; }
        public List<ModelSocialMedia> SocialMedia { get; set; }
        public ExchangeRate Currency2 { get; set; }
        public List<AlphavantageBaseModel> Currency { get; set; }
    }
    public class ModelCurrency
    {
        public int Unit { get; set; }

        public string Isim { get; set; }

        public string CurrencyName { get; set; }

        public string ForexBuying { get; set; }

        public string ForexSelling { get; set; }

        public string BanknoteBuying { get; set; }

        public string BanknoteSelling { get; set; }

        public string CrossRateUSD { get; set; }

        public string CrossRateOther { get; set; }
    }
}