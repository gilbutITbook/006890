using Dul.Board;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Dul.Tests
{
    [TestClass]
    public class BoardWriteFormTypeTest
    {
        [TestMethod]
        public void EnumTest()
        {
            Console.WriteLine(BoardWriteFormType.Write.ToFriendlyString());
        }
    }
}
