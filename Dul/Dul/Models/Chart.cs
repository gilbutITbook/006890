using System.Collections.Generic;

namespace Dul.Models
{
    public class Chart
    {

    }

    public class ChartRepositoryInMemory : IChartRepository
    {
        // 인-메모리 데이터 컬렉션
        public SortedList<int, double> GetChartMonthSumGenerations(int id)
        {
            var months = DateTimeUtility.GetTwelveMonthEmptyCollection();

            // 실제 1월부터 12월까지의 발전량 데이터 채우기
            months[1] = 10_000;
            months[2] = 6_000;
            months[3] = 7_000;
            months[4] = 7_500;
            months[5] = 6_000;
            months[6] = 4_500;
            months[7] = 5_000;
            months[8] = 6_000;
            months[9] = 7_000;
            months[10] = 7_500;
            months[11] = 6_000;
            months[12] = 4_500;

            return months;
        }

        public SortedList<int, double> GetChartMonthSumLoads(int id)
        {
            var months = DateTimeUtility.GetTwelveMonthEmptyCollection();

            // 실제 1월부터 12월까지의 발전량 데이터 채우기
            months[1] = 5_000;
            months[2] = 6_000;
            months[3] = 7_000;
            months[4] = 7_500;
            months[5] = 6_000;
            months[6] = 4_500;
            months[7] = 5_000;
            months[8] = 6_000;
            months[9] = 7_000;
            months[10] = 7_500;
            months[11] = 6_000;
            months[12] = 4_500;

            return months;
        }
    }

    public class ChartRepository : IChartRepository
    {
        // TODO: 실제 데이터베이스에서 데이터를 가져와서 사용
        public SortedList<int, double> GetChartMonthSumGenerations(int id)
        {
            throw new System.NotImplementedException();
        }

        public SortedList<int, double> GetChartMonthSumLoads(int id)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IChartRepository
    {
        SortedList<int, double> GetChartMonthSumGenerations(int id);
        SortedList<int, double> GetChartMonthSumLoads(int id);
    }
}
