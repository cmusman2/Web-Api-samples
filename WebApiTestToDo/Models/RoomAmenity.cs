using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApiTestToDo.Models
{
    [XmlRoot("RoomAmenity", Namespace = "")]
    public class RoomAmenity
    {
        [XmlAttribute]
        public int amenityId { get; set; }

        [XmlElement]
        public string amenity { get; set; }
    }
}
