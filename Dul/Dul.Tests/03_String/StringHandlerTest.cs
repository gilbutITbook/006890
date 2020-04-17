using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dul.Tests
{
    [TestClass]
    public class StringHandlerTest
    {
        [TestMethod]
        public void StringHandlerInstance_CutString_기본테스트()
        {
            // Arrange
            var source = "안녕하세요. 반갑습니다.";
            var len = 5; 
            var expected = "안녕...";
            var handler = new StringHandlerInstance();

            // Act
            var actual = handler.CutString(source, len);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringHandlerStatic_CutString_기본테스트()
        {
            // Arrange
            var source = "안녕하세요. 반갑습니다.";
            var len = 6;
            var expected = "안녕하...";

            // Act
            var actual = StringHandlerStatic.CutString(source, len);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringHandler_CutString_확장메서드를_사용한_기본테스트()
        {
            // Arrange
            var source = "안녕하세요. 반갑습니다.";
            var len = 7;
            var expected = "안녕하세...";

            // Act
            var actual = source.CutString(len);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
