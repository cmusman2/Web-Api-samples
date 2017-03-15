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


        public async static Task<HotelDescription> GetHotelDetails(int hid)
        {
            HotelDescription h= await HotelSearch.GetHotelDetails(hid);

            return h;
        }


        public async static Task<List<hotelsummary>> GetHotels(String city, DateTime sdate, DateTime edate)
        {
            if (city=="noloc")
            city = "";
            if (city=="") //sample
             htls = new List<hotelsummary>
             {
                new hotelsummary{hotelid="277912",city="Ras Al Khaimah",lowrate="117.43",locationdescription="Near Khuzam Family Park",shortdescription="Located in Ras Al Khaimah, Bin Majid Beach Resort - All Inclusive is close to Khuzam Family Park and RAK Pearls Museum. This 4-star hotel is within close proximity of Ras Al-Khaimah Water Ski Club and Jungle Bungle.",name="Bin Majid Beach Resort - All Inclusive",address1="Jazirah Al Hamra Road", thumbnailurl="/hotels/2000000/2000000/1990400/1990350/6e7716c1_l.jpg"},
                new hotelsummary{hotelid="308491",city="Ras Al Khaimah",lowrate="173.96",locationdescription="In Ras Al Khaimah",shortdescription="Located in Ras Al Khaimah, The Cove Rotana Resort is by the sea and within the vicinity of Khuzam Family Park and Jungle Bungle. This 5-star hotel is within the vicinity of Ras Al-Khaimah Water Ski Club and RAK Pearls Museum.",name="The Cove Rotana Resort",address1="Al Hamra Road", thumbnailurl="/hotels/3000000/2440000/2431400/2431343/2431343_156_l.jpg"},
                new hotelsummary{hotelid="437195",city="Ras Al Khaimah",lowrate="384.02",locationdescription="In Ras Al Khaimah",shortdescription="With a stay at Rixos Bab Al Bahr - All Inclusive in Ras Al Khaimah, you'll be by the sea and close to Saqr Park. This 5-star resort is within the vicinity of Al Hamra Marina and Yacht Club and Iceland Water Park.",name="Rixos Bab Al Bahr - All Inclusive",address1="Al Marjan Island", thumbnailurl="/hotels/7000000/6360000/6354700/6354603/6354603_102_l.jpg"},

             };
            else
            htls= await HotelSearch.GetData(city, sdate, edate);

             return  htls;
        }

        public async static Task<List<hotelsummary>> GetHotels(String lat,String lang, int max, DateTime checkin, int nights)
        {
                htls = await HotelSearch.GetData(lat,lang,max, checkin, nights);

            return htls;
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