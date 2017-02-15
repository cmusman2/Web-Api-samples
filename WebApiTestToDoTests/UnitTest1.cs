using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiTestToDo.Controllers;
using WebApiTestToDo.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiTestToDo.Models.Logging;

namespace WebApiTestToDoTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [Owner("john")]
        [Priority(2)]
        public void TestMethodLocationList()
        {

            LocationsController c = new  LocationsController();

            IEnumerable<Location> list = c.GetAllLocations();

            string city = "";

           IEnumerator<Location>  enumer = list.GetEnumerator();

            if (enumer != null) enumer.MoveNext();
            city = enumer.Current.City;
            Assert.AreEqual(city, "Aberdeen");
            //a-arrange  
            //a-act
            //a-assert

        }

        [TestMethod]
        [Priority(2)]
        public async Task TestMethodHotelSearch() 
        {

            HotelsController hc = new HotelsController();
            System.Web.Http.IHttpActionResult hl = await hc.GetHotel("London");                      
            Assert.AreNotEqual(hl, 123);

        }

        [TestMethod]
        [Priority(1)]
        public async Task TestMethodAuth()
        {
            string auth = await new ClientAuthenticateRemote().authenticate();
            Assert.AreNotEqual(auth, "");

        }

        [TestMethod]
        [Priority(9)]
        public void TestMethodFileLog()
        {
            Logger.log(LogTargets.File, "message");
            string slog = "";
            Assert.AreEqual(slog, "");


        }
    }
}
