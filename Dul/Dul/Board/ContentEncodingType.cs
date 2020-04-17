namespace Dul.Board
{
    /// <summary>
    /// 게시판의 글 내용(Content)의 인코딩 처리 방식 
    /// </summary>
    public enum ContentEncodingType
    {
        /// <summary>
        /// 입력한 소스 그대로 표시(태그 실행하지 않음)
        /// </summary>
        Text,

        /// <summary>
        /// HTML로 실행
        /// </summary>
        Html,

        /// <summary>
        /// HTML로 샐행 + 엔터키(\r\n) 적용됨
        /// </summary>
        Mixed
    }
}
