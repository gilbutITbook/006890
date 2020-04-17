using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dul.Tests
{
    [TestClass]
    public class CreatorTest
    {
        [TestMethod]
        public void GetNameTest()
        {
            //[1] Arrange(정렬), Setup
            const string expected = "RedPlus";

            //[2] Act(동작), Execute
            var actual = Creator.GetName();

            //[3] Assert(어설션), Verify
            Assert.AreEqual(expected, actual);
        }
    }
}
