using System;
using System.Collections.Generic;

namespace Dul
{
    /// <summary>
    /// 날짜와 시간 관련 유틸리티 
    /// </summary>
    public class DateTimeUtility
    {
        /// <summary>
        /// 날짜 형식이 오늘 날짜면 시간 표시 다르면 날짜 표시
        /// </summary>
        public static string ShowTimeOrDate(object dt, string format = "yyyy-MM-dd")
        {
            if (dt != null && DateTime.TryParse(dt.ToString(), out DateTime dateTime))
            {
                if (dateTime.Date == DateTime.Now.Date)
                {
                    return dateTime.ToString("hh:mm:ss");
                }
                else
                {
                    return dateTime.ToString(format); // "yyyy-MM-dd" || "yy-MM-dd"
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 1부터 8760까지의 정수를 입력받아 해당 날짜를 반환해주는 함수 
        /// </summary>
        public static DateTime GetDateTimeFromYearlyHourNumber(int number)
        {
            return (new DateTime(2019, 1, 1, 0, 0, 0)).AddHours(--number);
        }

        /// <summary>
        /// 특정 월/일/시에 대한 년간 시간 값을 반환: 8760 시간만 다루기 
        /// </summary>
        public static int GetYearlyHourByDateTime(int month, int day, int hour)
        {
            int yearlyHour = 0;

            yearlyHour = (int)(new DateTime(2019, month, day, hour, 0, 0) 
                - new DateTime(2019, 1, 1, 0, 0, 0)).TotalHours;

            return ++yearlyHour; 
        }        

        /// <summary>
        /// 1부터 12까지의 키 값을 갖는 빈 컬렉션 반환
        /// </summary>
        public static SortedList<int, double> GetTwelveMonthEmptyCollection()
        {
            SortedList<int, double> months = new SortedList<int, double>();

            for (int i = 1; i <= 12; i++)
            {
                months.Add(i, 0.0); // 키는 유일한 값
            }

            return months;
        }

        /// <summary>
        /// 1부터 8760까지의 키 값을 갖는 빈 컬렉션 반환
        /// </summary>
        public static SortedList<int, double> GetOneYear8760TimeEmptyCollection()
        {
            SortedList<int, double> oneYear = new SortedList<int, double>();

            for (int i = 1; i <= 8760; i++)
            {
                oneYear.Add(i, 0.0); // 키는 유일한 값
            }

            return oneYear;
        }
    }
}
