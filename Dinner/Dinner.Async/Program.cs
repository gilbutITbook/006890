using Dinner.Common;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Dinner.Async
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Rice rice = await (new Cooking()).MakeRiceAsync(); // 스레드 차단: false
            Console.WriteLine($"밥 준비 완료: {rice.GetHashCode()}");

            Soup soup = await (new Cooking()).MakeSoupAsync();
            Console.WriteLine($"국 준비 완료: {soup.GetHashCode()}");

            Egg egg = await (new Cooking()).MakeEggAsync();
            Console.WriteLine($"달걀 준비 완료: {egg.GetHashCode()}");

            stopwatch.Stop();

            Console.WriteLine($"\n시간: {stopwatch.ElapsedMilliseconds}밀리초");
            Console.WriteLine("비동기 방식으로 식사 준비 완료");
        }
    }
}
