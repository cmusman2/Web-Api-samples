using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApiTestToDo.Models
{
    public class HotelRooms
    {
        [XmlElement(ElementName = "RoomType", Namespace = "")]
        public List<HotelRoomDetails> HotelRoomDetails { get; set; }  
    }
}