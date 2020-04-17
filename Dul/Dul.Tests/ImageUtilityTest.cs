using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dul.Tests
{
    [TestClass]
    public class ImageUtilityTest
    {
        [TestMethod]
        public void IsImageTest()
        {
            Assert.AreEqual(true, ImageUtility.IsImage("RedPlus.png"));
        }
    }
}
