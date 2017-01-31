using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApiTestToDoTests
{
    /// <summary>
    /// Summary description for UnitTest3
    /// </summary>
    [TestClass]
    public class UnitTest3
    {

        [TestMethod]
        public void TestMethod1()
        {
            int c = 200;
            c = c * 10;
            Assert.AreEqual(c, 2000);
        }
    }
}
