using System.Collections.Generic;
using System.Web.Http;
using WebApiTestToDo.Models;

namespace WebApiTestToDo.Controllers
{
    public class LocationsController : ApiController
    {
        public IEnumerable<Location> GetAllLocations()
        {
            return DataSource.GetLocation("");          
        }

        [HttpGet]
        public IEnumerable<Location> GetLocation([FromUri(Name = "id")]string loc)
        {
            return DataSource.GetLocation(loc);            
        }   
    }
}
