using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTestToDo.Models
{
    public class Location:IComparable<Location>
    {
        public string City { get; set; }
        public string CityCode { get; set; }
        public string CountryCode { get; set; }

        public int CompareTo(Location obj)
        {
            return City.CompareTo(obj.City);
        }


    }
}