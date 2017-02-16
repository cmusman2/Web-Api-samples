using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApiTestToDo.Models
{
    public class hotelSummaryDetails
    {
        private String Rate;

        [XmlElement(Namespace = "")]
        public String name { get; set; }

        [XmlElement(Namespace = "")]
        public String address1 { get; set; }

        [XmlElement(Namespace = "")]
        public String address2 { get; set; }

        [XmlElement(Namespace = "")]
        public String city { get; set; }

        [XmlElement(Namespace = "")]
        public String hotelRating { get; set; }

        [XmlElement(Namespace = "")]
        public String propertyCategory { get; set; } 

        [XmlElement(Namespace = "")]
        public String postalCode { get; set; }

        [XmlElement(Namespace = "")]
        public String countryCode { get; set; }

        [XmlElement(Namespace = "")]
        public String tripAdvisorRatingUrl { get; set; }

        [XmlElement(Namespace = "")]
        public String tripAdvisorRating { get; set; }

        [XmlElement(Namespace = "")]
        public String latitude { get; set; }

        [XmlElement(Namespace = "")]
        public String longitude { get; set; } 

        [XmlElement(Namespace = "")]
        public String ratecurrencycode { get; set; }


        [DisplayFormat(DataFormatString = "{0:#.#}")]
        [XmlElement(Namespace = "")]
        public String lowRate { get { return getCurrencySymbol(ratecurrencycode) + " " + Rate; } set { Rate = value; } }


        private string getCurrencySymbol(string cc)
        {
            if (cc == "USD") return "$";
            else
                if (cc == "EUR") return "€";
            else
                if (cc == "GBP") return "£";
            else
                return cc;


        }
    }
}