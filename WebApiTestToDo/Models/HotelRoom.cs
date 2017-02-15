using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTestToDo.Models
{
    public class HotelRoom
    {
        public List<HotelAmenity> Amaenities { get; set; }
        public string CancellationPolicy { get; set; }
        public string Description { get; set; }
        public Double DiscountedRate { get; set; }
        public int EanHotelId { get; set; }
        public string PromotionDescription { get; set; }
        public double Rate { get; set; }
        public string RoomType { get; set; }
        public string RoomTypeCode { get; set; }
        public string RoomTypeId { get; set; }
        public List<HotelImage> Images { get; set; }
    }
}