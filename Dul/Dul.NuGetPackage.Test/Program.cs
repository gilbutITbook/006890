using System;
using Dul; // NuGet에서 내려받은 Dul.dll 파일에 대한 네임스페이스 참조

class Program
{
    static void Main()
    {
        //[1] Creator 호출 테스트
        Console.WriteLine(Creator.GetName());

        //[2] Math 호출 테스트
        Console.WriteLine(Dul.Math.Abs(-1234)); // System.Math와 Dul.Math 충돌 방지

        //[3] StringLibrary 호출 테스트
        Console.WriteLine("안녕하세요.".CutStringUnicode(6));

        //[4] DateTimeUtility 호출 테스트
        Console.WriteLine(DateTimeUtility.ShowTimeOrDate(DateTime.Now));
    }
}
