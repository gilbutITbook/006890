namespace Dul
{
    public class StringHandlerInstance
    {
        /// <summary>
        /// 주어진 문자열을 주어진 길이만큼만 잘라서 반환. 나머지 부분은 '...'을 붙임.
        /// </summary>
        /// <param name="strCut">원본 문자열</param>
        /// <param name="intChar">잘라낼 길이</param>
        /// <returns>안녕하세요. => 안녕...</returns>
        public string CutString(string strCut, int intChar)
        {
            if (strCut.Length > (intChar - 3))
            {
                return strCut.Substring(0, intChar - 3) + "...";
            }
            return strCut;
        }
    }

    public static class StringHandlerStatic
    {
        /// <summary>
        /// 주어진 문자열을 주어진 길이만큼만 잘라서 반환. 나머지 부분은 '...'을 붙임.
        /// </summary>
        /// <param name="strCut">원본 문자열</param>
        /// <param name="intChar">잘라낼 길이</param>
        /// <returns>안녕하세요. => 안녕...</returns>
        public static string CutString(string strCut, int intChar)
        {
            if (strCut.Length > (intChar - 3))
            {
                return strCut.Substring(0, intChar - 3) + "...";
            }
            return strCut;
        }
    }

    /// <summary>
    /// 확장 메서드
    /// </summary>
    public static class StringHandler
    {
        /// <summary>
        /// 주어진 문자열을 주어진 길이만큼만 잘라서 반환. 나머지 부분은 '...'을 붙임.
        /// </summary>
        /// <param name="strCut">원본 문자열</param>
        /// <param name="intChar">잘라낼 길이</param>
        /// <returns>안녕하세요. => 안녕...</returns>
        public static string CutString(this string strCut, int intChar)
        {
            if (strCut.Length > (intChar - 3))
            {
                return strCut.Substring(0, intChar - 3) + "...";
            }
            return strCut;
        }
    }
}
