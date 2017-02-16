using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApiTestToDo.Models
{
    [XmlRoot("RoomType", Namespace = "")]
    public class HotelRoomDetails
    {
        [XmlAttribute]
        public string roomCode { get; set; }

        [XmlAttribute]
        public string roomTypeId { get; set; }

        [XmlElement(Namespace = "")]
        public string description { get; set; }

        [XmlElement(Namespace = "")]
        public string descriptionLong { get; set; }

        [XmlElement(ElementName = "roomAmenities" , Namespace ="")]
        public RoomAmenities RoomAmenitiesDetails { get; set; }
    }
}
