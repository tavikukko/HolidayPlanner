using System;
using HolidayPlanner;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Validators validator = new Validators();

            string iDate = "12-12-2021";
            DateTime oDate = Convert.ToDateTime(iDate);
            bool result = validator.IsFutureDate(oDate, out string error);
            Assert.IsTrue(result,
                   String.Format("Expected for '{0}': true; Actual: {1}",
                                 iDate, result));
        }
    }
}
