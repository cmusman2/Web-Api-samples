using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApiTestToDo.Models
{

    public class summryList
    {
        [XmlElement(ElementName = "hotelsummary", Namespace = "")]
        public List<hotelsummary> Hotels { get; set; }
    }
}