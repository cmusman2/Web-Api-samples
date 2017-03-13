using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BookaHotel.DAL
{
    public class HotelsDataSource
    {
        public static Task<string> doGetHotels()
        {
            string result = "";
            return Task.FromResult(result);
        }
    }
}