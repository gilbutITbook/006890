using System.IO;

namespace Dul
{
    /// <summary>
    /// 이미지 처리 관련 기본 유틸리티
    /// </summary>
    public class ImageUtility
    {
        /// <summary>
        /// 첨부된 파일이 이미지 파일인지 검사. 이미지 파일이면 true, 그렇지 않으면 false 반환
        /// </summary>
        /// <param name="fileName">전체 파일명(예를 들어, "JYP.JPG")</param>
        /// <returns>이미지 파일이면 true, 그렇지 않으면 false</returns>
        public static bool IsImage(string fileName)
        {
            // 확장자 추출(점(.) 포함)
            string strFileExt = Path.GetExtension(fileName).ToUpper();

            bool blnResult = false;
            string[] arrImgExt = { ".GIF", ".JPG", ".JPEG", ".PNG", ".BMP" };

            foreach (string strExt in arrImgExt)
            {
                if (strFileExt.Trim().ToUpper().Equals(strExt))
                {
                    blnResult = true;
                    break;
                }
            }

            return blnResult;
        }
    }
}
