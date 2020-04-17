using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Dul.Tests
{
    [TestClass]
    public class DateTimeUtilityTest
    {
        [TestMethod]
        public void ShowTimeOrDateTest()
        {
            // (현재 시간 == 오늘 날짜) => 01:01:01 형태
            var now = DateTime.Now;
            var expeted = now.ToString("hh:mm:ss");
            // [1] Assert 클래스의 주요 메서드를 사용하여 테스트 통과 확인
            Assert.AreEqual(expeted, DateTimeUtility.ShowTimeOrDate(now));
        }

        [TestMethod]
        public void ShowTimeOrDateTestOther()
        {
            // (현재 시간 != 오늘 날짜) => 2019-12-20 형태
            var prev = DateTime.Now.AddDays(-7);
            // [2] Assert 클래스 없이 직접 실행하는 경우는 테스트 바로 통과 
            // yyyy-MM-dd 형태
            Console.WriteLine(DateTimeUtility.ShowTimeOrDate(prev));
            // yy-MM-dd 형태
            Console.WriteLine(DateTimeUtility.ShowTimeOrDate(prev, "yy-MM-dd"));
        }

        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void GetYearlyHourByDateTime_Test()
        {
            //var last = DateTimeUtility.GetYearlyHourByDateTime(12, 31, 23);
            //Assert.AreEqual(8760, last);

            var last = DateTimeUtility.GetYearlyHourByDateTime(1, 1, 0);
            Assert.AreEqual(1, last);
        }
    }
}
