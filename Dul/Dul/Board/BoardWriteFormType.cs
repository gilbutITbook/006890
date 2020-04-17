namespace Dul.Board
{
    /// <summary>
    /// 게시판의 글쓰기 폼 구성 분류(Write, Modify, Reply)
    /// </summary>
    public enum BoardWriteFormType
    {
        /// <summary>
        /// 글 쓰기 페이지
        /// </summary>
        Write,

        /// <summary>
        /// 글 수정 페이지
        /// </summary>
        Modify,

        /// <summary>
        /// 글 답변 페이지
        /// </summary>
        Reply,

        /// <summary>
        /// 기본 페이지
        /// </summary>
        None
    }
}
