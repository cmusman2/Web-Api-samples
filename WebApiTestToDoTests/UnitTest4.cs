using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiTestToDo.Models;
using System.Threading.Tasks;

namespace WebApiTestToDoTests
{
    /// <summary>
    /// Summary description for UnitTest3
    /// </summary
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        [Priority(1)]
        public async Task TestMethodHotelDetails()
        {
            HotelDescription hd =   await HotelSearch.GetHotelDetails(274263);
            Assert.AreNotEqual(hd, null);
        }
    }
}
