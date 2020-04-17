namespace Dul.Board
{
    /// <summary>
    /// RelatedArticleOption 열거형을 문자열로 표시해주는 확장
    /// </summary>
    public static class RelatedArticleOptionExtensions
    {
        /// <summary>
        /// 열거형을 문자열로 표시
        /// </summary>
        public static string ToFriendlyString(this RelatedArticleOption rao)
        {
            string r = "";

            switch (rao)
            {
                case RelatedArticleOption.Prev:
                    //r = "이전글";
                    r = "Prev";
                    break;
                case RelatedArticleOption.Current:
                    //r = "현재글";
                    r = "Current";
                    break;
                case RelatedArticleOption.Next:
                    //r = "다음글";
                    r = "Next";
                    break;
                default:
                    r = "Current";
                    break;
            }

            return r;
        }
    }
}
