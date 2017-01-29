using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApiTestToDo.Models
{
    public class DataSource 
    {
        private static List<Location> list = new List<Location>();
        private static List<hotelsummary> htls = new List<hotelsummary>();


        public static List<hotelsummary> hotels { get { return htls; } set { htls = value; } }


        public async static Task<List<hotelsummary>> GetHotels(String city, DateTime sdate, DateTime edate)
        {
            if (city=="") //sample
             htls = new List<hotelsummary>
             {
                new hotelsummary{hotelid="1",name="Marriott"},
                new hotelsummary{hotelid="2",name="Holiday Inn"},
                new hotelsummary{hotelid="3",name="Crowne Plaza"}

             };
            else
            htls= await HotelSearch.GetData(city, sdate, edate);

             return  htls;
        }        

        public static List<Location> GetLocation(string loc)
        {
            list = new List<Location>()
            {
                new Location{City="Aberdeen", CountryCode="GB"},
                new Location{City="Edinburgh", CountryCode="GB"},
                new Location{City="Ellesmere Port", CountryCode="GB"},
                new Location{City="Birkenhead", CountryCode="GB"},
                new Location{City="Frankfurt", CountryCode="DE"},
                new Location{City="Sydney", CountryCode="AU"},
                new Location{City="Las Vegas", CountryCode="US"},
                new Location{City="Wilmslow, Manchester", CountryCode="GB"},
                new Location{City="Madrid", CountryCode="ES"},
                new Location{City="Dubai", CountryCode="AE"},
                new Location{City="Abu Dhabi", CountryCode="AE"},
                new Location{City="London", CountryCode="GB"},
                new Location{City="Manchester", CountryCode="GB"},
                new Location{City="Birmingham", CountryCode="GB"},
                new Location{City="Glasgow", CountryCode="GB"},
                new Location{City="Belfast", CountryCode="GB"},
                new Location{City="Cardiff", CountryCode="GB"}, 
                new Location{City="Liverpool", CountryCode="GB"},
                new Location{City="Southport", CountryCode="GB"},

                new Location{City="Leeds", CountryCode="GB"},
                new Location{City="New Castle", CountryCode="GB"},
                new Location{City="Stoke on Trent", CountryCode="GB"},
                new Location{City="Sheffield", CountryCode="GB"},
                new Location{City="Blackpool", CountryCode="GB"},
                new Location{City="Sale, Greater Manchester", CountryCode="GB"},
                new Location{City="Macclesfield", CountryCode="GB"},
                new Location{City="Crew", CountryCode="GB"},

                new Location{City="Chester", CountryCode="GB"}



            };
            var result = list;

            list.Sort();
            if (!String.IsNullOrEmpty(loc) && !String.IsNullOrWhiteSpace(loc))
                result = list.Where((p) => p.City.ToLower().Contains(loc.ToLower())).ToList();

            result = result.Take(10).ToList();//first 10 enough

            return result;
        }


    }
}