using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dul.Tests
{
    [TestClass]
    public class AssertDemo
    {
        [TestMethod]
        public void AssertAreEqualTest()
        {
            //Assert.AreEqual(
            //    expected: "비교할 첫 번째 개체", 
            //    actual: "비교할 두 번째 개체");
            Assert.AreEqual(1234, 1234);
        }
    }
}
