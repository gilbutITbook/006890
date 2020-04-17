using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dul.Tests.Mathematics
{
    [TestClass]
    public class DulMathTest
    {
        [TestMethod]
        public void AbsTest()
        {
            //[1] Arrange, Setup
            var expected = 1234;

            //[2] Act, Execute
            var actual = Dul.Math.Abs(-1234);

            //[3] Assert, Verify
            Assert.AreEqual(expected, actual); 
        }
    }
}
