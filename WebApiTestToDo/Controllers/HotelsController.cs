using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiTestToDo.Models;
using WebApiTestToDo.Security;

namespace WebApiTestToDo.Controllers
{
    public class HotelsController : ApiController
    {
        
        public async Task<IEnumerable<hotelsummary>> HotelsAll(int Id)
        {
            List<hotelsummary> hotels = await DataSource.GetHotels("", DateTime.Now, DateTime.Now);
            return hotels;
        }

        public async Task<IHttpActionResult> GetHotel([FromUri(Name = "id")]string Id)
        {

            var hotels = DataSource.hotels;
            if ( hotels == null  ||  hotels.Count == 0 )
                hotels = await DataSource.GetHotels(Id, DateTime.Now.AddDays(1), DateTime.Now.AddDays(2));


          //  List<hotelsummary> hs= await  HotelSearch.GetData("London", DateTime.Now.AddDays(1), DateTime.Now.AddDays(2));

                // hotelsummary hss = hs.First();

                /*if ( (!String.IsNullOrEmpty(Id)) && (!String.IsNullOrWhiteSpace(Id)) )
                {
                    var h = hotels.FirstOrDefault((hh) => hh.hotelid == Id);
                    if (h == null)
                        return NotFound();
                    return Ok(h);
                }*/
            return Ok(hotels);
            
            
        }

        // [AuthenticateHotelUsers]
        [IdentityBasicAuthentication]
        [Authorize]
        [Route("api/hotels/{hotelid}/{city}")]
        public async Task<IHttpActionResult> GetHotelDetails([FromUri(Name = "hotelid")]string Id, [FromUri(Name = "city")]string city)
        {

            //if (hotels == null)
            //{
            //  hotels = await HotelSearch.GetData(city, DateTime.Now.AddDays(1), DateTime.Now.AddDays(2));
            //}

            //var hotel = hotels.FirstOrDefault((h) => h.hotelid == Id);
            //var hotel = hotels.FirstOrDefault();


            var hotels = DataSource.hotels;
            hotelsummary hotel = null;
            if (hotels == null || hotels.Count == 0)
                hotels = await DataSource.GetHotels(city, DateTime.Now.AddDays(1), DateTime.Now.AddDays(2));

            if (hotels != null)
            {
                var htls = hotels.Where((h) => h.hotelid == Id);

                hotel = htls.FirstOrDefault();
            }

            //Hotel hotel = new Hotel();
            if (hotel == null)
            {
                hotel = new hotelsummary();
                hotel.name = "London Marriott Hotel Kensington";
                hotel.thumbnailurl = "http://images.lowestroomrates.com/hotels/1000000/20000/18800/18773/1d9042a6_l.jpg";
                hotel.hotelid = "114200";
                hotel.city = "London";
                hotel.address1 = "147 Cromwell Road, London, SW5 0TH, United Kingdom";
                hotel.lowrate = "206.07";
                hotel.postalcode = "SW5 0TH";
            }
            return Ok(hotel);

        }



        [DigestAuthorizationFilterAttribute]      
        [Route("api/hotels/{hotelid}/{city}/{country}")]
        public async Task<IHttpActionResult> GetHotelDetailsSpecials([FromUri(Name = "hotelid")]string Id, [FromUri(Name = "city")]string city, [FromUri(Name = "country")]string country)
        {
              
            //if (hotels == null)
            //{
            //  hotels = await HotelSearch.GetData(city, DateTime.Now.AddDays(1), DateTime.Now.AddDays(2));
            //}

            //var hotel = hotels.FirstOrDefault((h) => h.hotelid == Id);
            //var hotel = hotels.FirstOrDefault();


            var hotels = DataSource.hotels;
            hotelsummary hotel =null;
            if (hotels == null || hotels.Count == 0)
                hotels = await DataSource.GetHotels(city, DateTime.Now.AddDays(1), DateTime.Now.AddDays(2));

            if (hotels != null)
            {
                var htls = hotels.Where((h) => h.hotelid == Id);

                hotel = htls.FirstOrDefault();
            }
            //Hotel hotel = new Hotel();
            if (hotel == null)
            {
                hotel = new hotelsummary();
                hotel.name = "London Marriott Hotel Kensington";
                hotel.thumbnailurl = "http://images.lowestroomrates.com/hotels/1000000/20000/18800/18773/1d9042a6_l.jpg";
                hotel.hotelid = "114200";
                hotel.city = "London";
                hotel.address1 = "147 Cromwell Road, London, SW5 0TH, United Kingdom";
                hotel.lowrate = "206.07";
                hotel.postalcode = "SW5 0TH";
            }
            return Ok(hotel);

        }

    }
}
