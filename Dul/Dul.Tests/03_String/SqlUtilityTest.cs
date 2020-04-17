using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Dul.Tests
{
    [TestClass]
    public class SqlUtilityTest
    {
        [TestMethod]
        public void EncodeSqlStringTest()
        {
            Console.WriteLine(SqlUtility.EncodeSqlString("@'_%"));
        }
    }
}
