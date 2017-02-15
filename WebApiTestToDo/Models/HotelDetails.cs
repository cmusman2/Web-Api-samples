using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTestToDo.Models
{
    public class HotelDetails
    {
        public string EanHotelId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; } 
        public string PostalCode { get; set; } 
        public string CountryCode { get; set; }
        public string StateProvince { get; set; }
        public string SupplierType  { get; set; }
        public string CheckinTime  { get; set; }
        public string CheckoutTime { get; set; }
        public string ChainCode { get; set; }
         
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string HotelCurrency  { get; set; }
        public string ProximityDistance  { get; set; }
        public string StarRating { get; set; }
        public string TripAvisorRating  { get; set; }
        public string TripAvisorRatingUrl { get; set; }
        public string PropertyCategory { get; set; }

        public string LowRate { get; set; } 
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Dining { get; set; }
        public string LocalArea { get; set; }
        public string HotelPolicy  { get; set; }

        public List<HotelRoom> HotelRooms { get; set; }
        public List<HotelImage> HotelImages { get; set; }
        public List<HotelAmenity> HotelAmenities { get; set; }  


    }
}