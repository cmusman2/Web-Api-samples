using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiTestToDo.Models;

namespace WebApiTestToDo.Controllers
{
    public class LocationsController : ApiController
    {
        public async Task<IHttpActionResult> GetAllLocations()
        {
            var a = await DataSource.GetLocation("");
            return Ok(a);
        }
        

       [Route("locations/autoComplete/{loc}")]
        public async Task<IHttpActionResult> GetLocations([FromUri(Name = "loc")]string loc)
        {
            var l = await DataSource.GetLocations(loc); 
            return Ok(l);
        }

        [Route("locations/autoCompleteLocal/{loc}")]
        public async Task<IHttpActionResult> GetLocation([FromUri(Name = "loc")]string loc)
        {
            var l = await DataSource.GetLocation(loc);
            return Ok(l);
        }
    }
}
