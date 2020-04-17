using Dul.Board;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dul.Tests
{
    [TestClass]
    public class BoardHelperTest
    {
        [TestMethod]
        public void ValidTableNameTest()
        {
            Assert.IsFalse(BoardHelper.ValidTableName("Notice%"));
            Assert.IsTrue(BoardHelper.ValidTableName("Free"));
        }
    }
}
