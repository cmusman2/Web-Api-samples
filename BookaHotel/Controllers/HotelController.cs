using BookaHotel.DAL;
using BookaHotel.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookaHotel.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SearchHotels(SearchHotelForm model, string returnUrl)
        {
           var result = await HotelsDataSource.doGetHotels();

            if (!ModelState.IsValid) 
            {
                return View(model);
            }

            return View(model);
        }
    }
}