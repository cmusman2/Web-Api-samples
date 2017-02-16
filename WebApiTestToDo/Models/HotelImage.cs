using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApiTestToDo.Models
{
    [XmlRoot("HotelImage", Namespace = "")]
    public class HotelImage
    {
        [XmlElement(Namespace = "")]
        public int category { get; set; }

        [XmlElement(Namespace = "")]
        public int type { get; set; }
         
        [XmlElement(Namespace = "")]
        public float width { get; set; }

        [XmlElement(Namespace = "")]
        public float height { get; set; }

        [XmlElement(Namespace = "")]
        public string url { get; set; }

        [XmlElement(Namespace = "")]
        public string thumbnailUrl { get; set; }

        [XmlElement(Namespace = "")]
        public string caption { get; set; }

    }
}