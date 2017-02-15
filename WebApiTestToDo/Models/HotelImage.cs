using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTestToDo.Models
{
    public class HotelImage
    {
        public Boolean DefaultImage { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public string Url { get; set; } 
        public string ThumbNailUrl { get; set; }
        public string ImageCaption { get; set; }

    }
}