namespace Dul.Board
{
    public static class CopyTypeExtensions
    {
        public static string ToFriendlyString(this CopyType copyType)
        {
            string r = "";

            switch (copyType)
            {
                case CopyType.Copy:
                    r = "복사";
                    break;
                case CopyType.Move:
                    r = "이동";
                    break;
                default:
                    r = "복사";
                    break;
            }

            return r;
        }
    }
}
