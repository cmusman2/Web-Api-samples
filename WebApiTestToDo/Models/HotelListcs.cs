using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApiTestToDo.Models
{

    [XmlRoot("hotellistresponse", Namespace = "http://v3.hotel.wsapi.ean.com/")]
    public class HotelList
    {


        [XmlElement(ElementName = "hotellist", Namespace = "")]
        public summryList Hotels { get; set; }

        [XmlElement(Namespace = "")]
        public String customersessionid { get; set; }
        [XmlElement(Namespace = "")]
        public String numberofroomsrequested { get; set; }
        [XmlElement(Namespace = "")]
        public String moreresultsavailable { get; set; }
    }
}