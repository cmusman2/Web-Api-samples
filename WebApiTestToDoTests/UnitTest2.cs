using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApiTestToDoTests
{
    /// <summary>
    /// Summary description for UnitTest2
    /// </summary>
    [TestClass]
    public class UnitTest2
    {

        [TestMethod]
        public void TestMethod1()
        {
            int count =10;
            count = count * 12;
            Assert.AreEqual(count, 120);

        }

        [TestMethod]
        public void TestMethod2()
        {
            int count = 10;
            count = count * 12;
            Assert.AreEqual(count, 120);

        }


        [TestMethod]
        public void TestMethod3()
        {
            int count = 10;
            count = count * 12;
            Assert.AreEqual(count, 120);

        }
    }
}
