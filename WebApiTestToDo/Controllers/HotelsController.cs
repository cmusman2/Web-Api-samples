using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using WebApiTestToDo.ExceptionHandling;
using WebApiTestToDo.Models;
using WebApiTestToDo.Security;

namespace WebApiTestToDo.Controllers
{
   // [HotelControllerExceptionFilterAttribute]
    public class HotelsController : ApiController
    {
        
        public async Task<IEnumerable<hotelsummary>> HotelsAll(int Id)
        {
            List<hotelsummary> hotels = await DataSource.GetHotels("", DateTime.Now, DateTime.Now);
            return hotels;
        }

        
        [Route("hotels/{city}")]
        public async Task<IHttpActionResult> GetHotel([FromUri(Name = "city")]string city)
        {

            int[] tt = new int[2];
           
                int j = tt[2];
          

            var hotels= DataSource.hotels; 
          //  if ( hotels == null  ||  hotels.Count == 0 )
                hotels = await DataSource.GetHotels(city, DateTime.Now.AddDays(1), DateTime.Now.AddDays(2));


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

        [Route("hotels/{lat}/{lang}/{max}/{checkin}/{nights}")]
        public async Task<IHttpActionResult> GetHotel2([FromUri(Name = "lat")]string lat,
                                                       [FromUri(Name = "lang")]string lang,
                                                       [FromUri(Name = "max")]int max,
                                                       [FromUri(Name = "checkin")]string checkin,
                                                       [FromUri(Name = "nights")]int nights)
        { 

            var hotels = DataSource.hotels;
            //  if ( hotels == null  ||  hotels.Count == 0 )

            int d=0, m=0, y = 0; DateTime dt;
            try
            {//17MAY17
                Int32.TryParse(checkin.Substring(0, 2), out d);
                m = GetMonthNum(checkin.Substring(2, 3));
                Int32.TryParse(checkin.Substring(5, 2), out y);
            }catch(Exception exp) { }

            if (d>0 && m>0 && y>0)
            {
                if (y.ToString().Length == 2) y = 2000 + y ;
               dt= new DateTime(y, m, d);
             
            }
            else
             dt = DateTime.Now.AddDays(7);

              if((dt - DateTime.Now).TotalDays>360) dt = DateTime.Now.AddDays(7);


            hotels = await DataSource.GetHotels(lat,lang,max, dt, nights);


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

        [DigestAuthorizationFilterAttribute]
        [Route("hoteldetails/{hotelid}")]
        public async Task<IHttpActionResult> GetHotelDetails([FromUri(Name = "hotelid")]int hid) 
        {

           var htl= await DataSource.GetHotelDetails(hid);
            return Ok(htl);

        }

        // [AuthenticateHotelUsers]
        [IdentityBasicAuthentication]
        [Authorize]
        [Route("hotels/{hotelid}/{city}")]
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
        [Route("hotels/{hotelid}/{city}/{country}")]
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



        private int GetMonthNum(string m)
        {
            if (m.ToLower().Equals("jan")) return 1;else
            if (m.ToLower().Equals("feb")) return 2;
            else if (m.ToLower().Equals("mar")) return 3;
            else
            if (m.ToLower().Equals("apr")) return 4;
            else
            if (m.ToLower().Equals("may")) return 5;
            else
            if (m.ToLower().Equals("jun")) return 6;
            else
            if (m.ToLower().Equals("jul")) return 7;
            else
            if (m.ToLower().Equals("aug")) return 8;
            else
            if (m.ToLower().Equals("sep")) return 9;
            else
            if (m.ToLower().Equals("oct")) return 10;
            else
            if (m.ToLower().Equals("nov")) return 11;
            else
            if (m.ToLower().Equals("dec")) return 12;
            else


                return 0;
        }

    }
}
