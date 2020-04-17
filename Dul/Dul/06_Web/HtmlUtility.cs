using System;

namespace Dul
{
    public class HtmlUtility
    {
        #region Encode() 함수
        /// <summary>
        /// HTML을 실행하지 않고 소스 그대로 표현해서 바로 웹 페이지에 보여줌
        /// </summary>
        /// <param name="strContent">HTML 태그가 포함된 문자열</param>
        /// <returns>태그가 인코드되어 소스 그대로 표현될 문자열</returns>
        public static string Encode(string strContent)
        {
            string strTemp = "";
            if (String.IsNullOrEmpty(strContent))
            {
                strTemp = "";
            }
            else
            {
                strTemp = strContent;
                strTemp = strTemp.Replace("&", "&amp;");
                strTemp = strTemp.Replace(">", "&gt;");
                strTemp = strTemp.Replace("<", "&lt;");
                //strTemp = strTemp.Replace("\r\n", "<br />");
                strTemp = strTemp.Replace("\n", "<br />"); // \r\n 최근 브라우저 인식 오류
                strTemp = strTemp.Replace("\"", "&#34;");
            }
            return strTemp;
        }
        #endregion

        #region EncodeWithTabAndSpace() 함수
        /// <summary>
        /// HTML을 실행하지 않고 소스 그대로 표현해서 바로 웹 페이지에 보여줌
        /// 추가적으로 탭과 공백도 HTML 코드(&nbsp;)로 처리해서 출력
        /// </summary>
        /// <param name="strContent">HTML 태그가 포함된 문자열</param>
        /// <returns>태그가 인코드되어 소스 그대로 표현될 문자열</returns>
        public static string EncodeWithTabAndSpace(string strContent)
        {
            return Encode(strContent)
                .Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;")
                .Replace(" " + " ", "&nbsp;&nbsp;");
        }
        #endregion
    }
}
