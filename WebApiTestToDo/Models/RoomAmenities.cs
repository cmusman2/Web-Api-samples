using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApiTestToDo.Models
{
    public class RoomAmenities
    {
        [XmlElement(ElementName = "RoomAmenity", Namespace = "")]
        public List<RoomAmenity> RoomAmenityDetails { get; set; }

        [XmlAttribute] 
        public int size { get; set; }
    }
}