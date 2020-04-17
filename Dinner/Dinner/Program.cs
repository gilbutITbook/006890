using Dinner.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Dinner
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("[?] 어떤 방식으로 실행할까요? (0~4 번호 입력)\n" +
                "0. 동기\t\t1. await\t2. Task<T>\t3. WhenAll\t4. WhenAny ");
            var number = Convert.ToInt32(Console.ReadLine());

            switch (number)
            {
                case 1: // 비동기(동기 프로그램을 포함한)
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();

                        Egg egg = await (new Cooking()).MakeEggAsync();
                        Console.WriteLine($"달걀 재료 준비 완료: {egg.GetHashCode()}");

                        Rice rice = await (new Cooking()).MakeRiceAsync(); 
                        Console.WriteLine($"김밥 준비 완료: {rice.GetHashCode()}");

                        Soup soup = await (new Cooking()).MakeSoupAsync();
                        Console.WriteLine($"국 준비 완료: {soup.GetHashCode()}");
                        
                        stopwatch.Stop();

                        Console.WriteLine($"\n시간: {stopwatch.ElapsedMilliseconds}");
                        Console.WriteLine("비동기 방식으로 식사(김밥) 준비 완료");
                    }
                    break;
                case 2: // 비동기(함께 실행)
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();

                        // 3개의 Async 메서드가 동시 실행
                        Task<Rice> riceTask = (new Cooking()).MakeRiceAsync();
                        Task<Soup> soupTask = (new Cooking()).MakeSoupAsync();
                        Task<Egg> eggTask = (new Cooking()).MakeEggAsync();

                        Rice rice = await riceTask;
                        Console.WriteLine($"식탁에 밥 준비 완료: {rice.GetHashCode()}");
                        Soup soup = await soupTask;
                        Console.WriteLine($"식탁에 국 준비 완료: {soup.GetHashCode()}");
                        Egg egg = await eggTask;
                        Console.WriteLine($"식탁에 달걀 준비 완료: {egg.GetHashCode()}");

                        stopwatch.Stop();

                        Console.WriteLine($"\n시간: {stopwatch.ElapsedMilliseconds}");
                        Console.WriteLine("비동기 방식으로 식사 준비 완료");
                    }
                    break;
                case 3: // 비동기(모두 완료되는 시점)
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();

                        // 3개의 Async 메서드가 동시 실행
                        Task<Rice> riceTask = (new Cooking()).MakeRiceAsync();
                        Task<Soup> soupTask = (new Cooking()).MakeSoupAsync();
                        Task<Egg> eggTask = (new Cooking()).MakeEggAsync();

                        // 모든 작업이 다 완료될 때까지 대기
                        await Task.WhenAll(riceTask, soupTask, eggTask);

                        Console.WriteLine("식탁에 모든 식사 준비 완료");

                        stopwatch.Stop();

                        Console.WriteLine($"\n시간: {stopwatch.ElapsedMilliseconds}");
                        Console.WriteLine("비동기 방식으로 식사 준비 완료");
                    }
                    break;
                case 4:
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();

                        // 3개의 Async 메서드가 동시 실행
                        Task<Rice> rTask = (new Cooking()).MakeRiceAsync();
                        Task<Soup> sTask = (new Cooking()).MakeSoupAsync();
                        Task<Egg> eTask = (new Cooking()).MakeEggAsync();

                        // 하나라도 작업이 끝나면 확인
                        var allTasks = new List<Task> { rTask, sTask, eTask };
                        while (allTasks.Any()) // 작업이 하나라도 있으면 실행
                        {
                            Task finished = await Task.WhenAny(allTasks);
                            if (finished == rTask)
                            {
                                Rice rice = await rTask;
                                Console.WriteLine($"밥 준비 완료 - {rice}");
                            }
                            else if (finished == sTask)
                            {
                                Soup soup = await sTask;
                                Console.WriteLine($"국 준비 완료 - {soup}");
                            }
                            else
                            {
                                Egg egg = await eTask;
                                Console.WriteLine($"달걀 준비 완료 - {egg}");
                            }
                            allTasks.Remove(finished); // 끝난 작업은 리스트에서 제거
                        }

                        stopwatch.Stop();

                        Console.WriteLine(
                            $"\n시간: {stopwatch.ElapsedMilliseconds}");
                        Console.WriteLine("비동기 방식으로 식사 준비 완료");
                    }
                    break;
                default: // 동기(Sync)
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();

                        //[1] 밥 만들기
                        Rice rice = (new Cooking()).MakeRice(); // 스레드 차단: true
                        Console.WriteLine($"밥 준비 완료 - {rice.GetHashCode()}");

                        //[2] 국 만들기
                        Soup soup = (new Cooking()).MakeSoup();
                        Console.WriteLine($"국 준비 완료 - {soup.GetHashCode()}");

                        //[3] 달걀 만들기
                        Egg egg = (new Cooking()).MakeEgg();
                        Console.WriteLine($"달걀 준비 완료 - {egg.GetHashCode()}");

                        stopwatch.Stop();

                        Console.WriteLine($"\n시간: {stopwatch.ElapsedMilliseconds}");
                        Console.WriteLine("동기 방식으로 식사 준비 완료");
                    }
                    break;
            }
        }
    }
}
