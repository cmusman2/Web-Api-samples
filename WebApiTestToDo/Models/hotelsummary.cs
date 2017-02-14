using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApiTestToDo.Models
{
    public class hotelsummary
    {
        private String Rate;
        private String ShortDescription;


        private String thumbnailUrl;
        [XmlElement(Namespace = "")]
        public String hotelid { get; set; }

        [XmlElement(Namespace = "")]
        public String name { get; set; }

        [XmlElement(Namespace = "")]
        public String address1 { get; set; }

        [XmlElement(Namespace = "")]
        public String city { get; set; }

        [XmlElement(Namespace = "")]
        public String postalcode { get; set; }

        [XmlElement(Namespace = "")]
        public String countrycode { get; set; }

        [XmlElement(Namespace = "")]
        public String tripadvisorratingurl { get; set; }

        [XmlElement(Namespace = "")]
        public String thumbnailurl
        {
            get
            {
                if (!String.IsNullOrEmpty(thumbnailUrl))
                {

                    thumbnailUrl = thumbnailUrl.Replace("_t.", "_l.");
                }
                return thumbnailUrl;
            }
            set { thumbnailUrl = "http://images.lowestroomrates.com" + value; }
        }

        [XmlElement(Namespace = "")]
        public String ratecurrencycode { get; set; }

        [XmlElement(Namespace = "")]
        public String locationdescription { get; set; }

        [XmlElement(Namespace = "")]
        public String shortdescription { get { if ((!String.IsNullOrEmpty(ShortDescription)) && (ShortDescription.IndexOf("br /&gt;") >0)) ShortDescription = ShortDescription.Substring(ShortDescription.IndexOf("br /&gt;") + 8) + "..."; return ShortDescription; } set { ShortDescription = value; } }

        [DisplayFormat(DataFormatString = "{0:#.#}")]
        [XmlElement(Namespace = "")]
        public String lowrate { get { return getCurrencySymbol(ratecurrencycode) + " " + Rate; } set { Rate = value; } }


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