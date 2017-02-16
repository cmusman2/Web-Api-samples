using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApiTestToDo.Models
{
    public class PropertyAmenities
    {
        [XmlElement(ElementName = "PropertyAmenity", Namespace ="")]
        public List<PropertyAmenity> PropertyAmenitiesDetails { get; set; }

    }
}