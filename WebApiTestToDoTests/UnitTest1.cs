using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiTestToDo.Controllers;
using WebApiTestToDo.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiTestToDoTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [Owner("John")]
        public void TestMethod1()
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
        [Priority(9)]
        [Owner("John")]
        public async Task TestMethod2() 
        {

            HotelsController hc = new HotelsController();
            System.Web.Http.IHttpActionResult hl = await hc.GetHotel("London");                      
            Assert.AreNotEqual(hl, null);

        }
    }
}
