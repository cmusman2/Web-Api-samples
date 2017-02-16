using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApiTestToDo.Models
{
    public class HotelImages
    {
        [XmlElement(ElementName = "HotelImage", Namespace = "")]
        public List<HotelImage> Images { get; set; }
    }
}