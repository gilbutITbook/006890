namespace Dul.Board
{
    /// <summary>
    /// 게시판의 글쓰기의 내용의 형식(Encoding Type) 종류: Html | Text | Mixed
    /// </summary>
    public static class ContentTypes
    {
        /// <summary>
        /// 'Text/HTML' 는 HTML 코드를 실행한 결과를 보여줍니다.
        /// </summary>
        public const string Html = "Text/HTML"; 

        /// <summary>
        /// 'Plain-Text' 는 HTML 코드를 실행하지 않고 내용 그대로를 보여줍니다.
        /// </summary>        
        public const string Text = "Plain-Text"; 

        /// <summary>
        /// 'Mixed-Text' 는 HTML 코드를 실행하되 자동 줄바꾸기를 해줍니다.
        /// </summary>
        public const string Mixed = "Mixed-Text";
    }
}
