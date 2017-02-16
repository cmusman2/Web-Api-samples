using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApiTestToDo.Models
{
    public class HotelDetailsDescription
    {
        [XmlElement(Namespace = "")]
        public int numberOfRooms { get; set; }

        [XmlElement(Namespace = "")]
        public int numberOfFloors { get; set; }

        [XmlElement(Namespace = "")]
        public string checkInTime { get; set; }

        [XmlElement(Namespace = "")]
        public string checkOutTime { get; set; }
        
        [XmlElement(Namespace = "")]
        public string propertyInformation { get; set; }
       

        [XmlElement(Namespace = "")]
        public string areaInformation { get; set; }

        [XmlElement(Namespace = "")]
        public string propertyDescription { get; set; }

        [XmlElement(Namespace = "")]
        public string hotelPolicy { get; set; }

        [XmlElement(Namespace = "")]
        public string roomInformation { get; set; }

        [XmlElement(Namespace = "")]
        public string drivingDirections { get; set; }

        [XmlElement(Namespace = "")]
        public string checkInInstructions { get; set; }

        [XmlElement(Namespace = "")]
        public string knowBeforeYouGoDescription { get; set; }

        [XmlElement(Namespace = "")]
        public string roomFeesDescription { get; set; }

        [XmlElement(Namespace = "")]
        public string mandatoryFeesDescription { get; set; }

        [XmlElement(Namespace = "")]
        public string renovationsDescription { get; set; }

        [XmlElement(Namespace = "")]
        public string locationDescription { get; set; }

        [XmlElement(Namespace = "")]
        public string diningDescription { get; set; }

        [XmlElement(Namespace = "")]
        public string amenitiesDescription { get; set; }

        [XmlElement(Namespace = "")]
        public string businessAmenitiesDescription { get; set; }

        [XmlElement(Namespace = "")]
        public string roomDetailDescription { get; set; }
   


    }
}