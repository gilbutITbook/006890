namespace Dul
{
    /// <summary>
    /// 문자열 변환기
    /// </summary>
    public class StringConverter
    {
        /// <summary>
        /// 초간단 문자열 인코딩
        /// </summary>
        public static string ConvertToSimpleEncoding(string original)
        {
            byte[] byt = System.Text.Encoding.UTF8.GetBytes(original);
            return System.Convert.ToBase64String(byt); // 암호화
        }

        /// <summary>
        /// 초간단 문자열 디코딩
        /// </summary>
        public static string ConvertToSimpleDecoding(string modified)
        {
            byte[] byt = System.Convert.FromBase64String(modified);
            return System.Text.Encoding.UTF8.GetString(byt); // 복호화
        }
    }
}
