namespace Dul.Board
{
    public static class BoardWriteFormTypeExtensions
    {
        public static string ToFriendlyString(this BoardWriteFormType bwft)
        {
            string r = "";

            switch (bwft)
            {
                case BoardWriteFormType.Write:
                    r = "글 쓰기 페이지";
                    break;
                case BoardWriteFormType.Modify:
                    r = "글 수정 페이지";
                    break;
                case BoardWriteFormType.Reply:
                    r = "글 답변 페이지";
                    break;
                default:
                    r = "기본 페이지";
                    break;
            }

            return r;
        }
    }
}
