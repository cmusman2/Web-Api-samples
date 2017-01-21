using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiTestToDo.Models;

namespace WebApiTestToDo.Controllers
{
    public class HotelsController : ApiController
    {
        List<hotelsummary> hotels;
        public IEnumerable<hotelsummary> HotelsAll(int Id)
        {
            hotels = new List<hotelsummary>
             {
                new hotelsummary{hotelid="1",name="Marriott"},
                new hotelsummary{hotelid="2",name="Holiday Inn"},
                new hotelsummary{hotelid="3",name="Crowne Plaza"}

             };
             return hotels;
        }

        public async Task<IHttpActionResult> GetHotel(string Id)
        {
            if (hotels == null)
            {
                hotels = await HotelSearch.GetData(Id, DateTime.Now.AddDays(1), DateTime.Now.AddDays(2));
            }


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
    }
}
