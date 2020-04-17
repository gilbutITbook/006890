namespace Dul.Board
{
    /// <summary>
    /// 게시판(Board) 관련 유틸리티
    /// </summary>
    public class BoardHelper
    {
        /// <summary>
        /// Table 이름(BoardAlias)에 대한 유효성 검사: 잘못된 문자열 입력 방지
        /// </summary>
        public static bool ValidTableName(string tableName)
        {
            string[] arrChar = { @"\", @"/", ":", "?", "*", "" + (char)34, "<", ">", "|", " ", "'", "%", "&", "+", ".", ",", "-", "_" };
            bool blnTemp = true;
            foreach (string s in arrChar)
            {
                if (tableName.IndexOf(s) != -1)
                {
                    blnTemp = false;
                }
            }

            return blnTemp;
        }
    }
}
