namespace Dul
{
    /// <summary>
    /// Math 클래스 모방
    /// </summary>
    public class Math
    {
        /// <summary>
        /// 절댓값 구하기 
        /// </summary>
        /// <param name="number">자연수</param>
        /// <returns>절댓값</returns>
        public static int Abs(int number) => (number < 0) ? -number : number;
    }
}
