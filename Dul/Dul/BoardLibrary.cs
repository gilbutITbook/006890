using System;
using System.IO;

namespace Dul
{
    /// <summary>
    /// 게시판 관련 주요 기능에 대한 메서드 제공
    /// </summary>
    public class BoardLibrary
    {
        #region 각 글의 Step별 들여쓰기 처리
        /// <summary>
        /// 각 글의 Step별 들여쓰기 처리
        /// </summary>
        /// <param name="objStep">1, 2, 3</param>
        /// <returns>Re 이미지를 포함한 Step만큼 들여쓰기</returns>
        public static string FuncStep(object objStep, string imgUrl = "/images/DNN/")
        {
            int intStep = Convert.ToInt32(objStep);
            string strTemp = String.Empty;
            if (intStep == 0)
            {
                strTemp = String.Empty;
            }
            else
            {
                for (int i = 0; i < intStep; i++)
                {
                    strTemp = String.Format("<img src=\"{0}blank.gif\" height=\"{1}\" width=\"{2}\">", imgUrl, "0", (intStep * 15));
                }
                strTemp += "<img src=\"" + imgUrl + "re.gif\">";
            }
            return strTemp;
        }
        #endregion

        #region 댓글 개수를 표현하는 메서드
        /// <summary>
        /// 댓글 개수를 표현하는 메서드
        /// </summary>
        /// <param name="objCommentCount">댓글 수</param>
        /// <returns>댓글 이미지와 함께 숫자 표시</returns>
        public static string ShowCommentCount(object objCommentCount, string imgUrl = "/images/dnn/")
        {
            string strTemp = "";
            try
            {
                if (Convert.ToInt32(objCommentCount) > 0)
                {
                    strTemp = "<img src=\"" + imgUrl + "commentcount.gif\" />";
                    strTemp += "<span style='font-size:10px;'>(" + objCommentCount.ToString() + ")</span>";
                }
            }
            catch (Exception)
            {
                strTemp = "";
            }
            return strTemp;
        }
        #endregion

        #region 24시간내에 올라온 글 new 이미지 표시하기
        /// <summary>
        /// 24시간내에 올라온 글 new 이미지 표시하기
        /// </summary>
        public static string FuncNew(object strDate, string imgUrl = "/images/MemoEngine/")
        {
            if (strDate != null)
            {
                if (!String.IsNullOrEmpty(strDate.ToString()))
                {
                    DateTime originDate = Convert.ToDateTime(strDate);

                    TimeSpan objTs = DateTime.Now - originDate;
                    string newImage = "";
                    if (objTs.TotalMinutes < 1440)
                    {
                        newImage = "<img src=\"" + imgUrl + "new.gif\" alt=\"new\">";
                    }
                    return newImage;
                }
            }
            return "";
        }
        #endregion

        #region 넘겨온 날짜 형식이 오늘 날짜면 시간 표시
        /// <summary>
        /// 넘겨온 날짜 형식이 오늘 날짜면 시간 표시, 
        /// 그렇지않으면 날짜표시
        /// </summary>
        public static string FuncShowTime(object date)
        {
            if (date != null)
            {
                if (!String.IsNullOrEmpty(date.ToString()))
                {
                    string strPostDate =
                      Convert.ToDateTime(date).ToString("yyyy-MM-dd");
                    if (strPostDate == DateTime.Now.ToString("yyyy-MM-dd"))
                    {
                        return Convert.ToDateTime(date).ToString("hh:mm:ss");
                    }
                    else
                    {
                        return strPostDate;
                    }
                }
            }
            return "-";
        }
        #endregion

        #region ConvertToFileSize() 함수
        /// <summary>
        /// 파일 크기를 계산해서 알맞은 단위로 변환해줌. (바이트 수)
        /// </summary>
        public static string ConvertToFileSize(int intByte)
        {
            int intFileSize = Convert.ToInt32(intByte);
            string strResult = "";
            if (intFileSize >= 1048576)
            {
                strResult = string.Format("{0:F} MB", (intByte / 1048576));
            }
            else
            {
                if (intFileSize >= 1024)
                {
                    strResult = string.Format("{0} KB", (intByte / 1024));
                }
                else
                {
                    strResult = intByte + " Byte(s)";
                }
            }
            return strResult;
        }
        #endregion

        #region IsPhoto() 함수
        /// <summary>
        /// 파일 확장자를 확인해서 파일이 이미지 파일인지 검사
        /// </summary>
        /// <param name="strFileNameTemp">확장자를 포함한 파일(Test.png)</param>
        /// <returns>이미지 확장자이면 true 그렇지 않으면 false</returns>
        public static bool IsPhoto(string strFileNameTemp)
        {
            string ext =
                Path.GetExtension(strFileNameTemp).Replace(".", "").ToLower();
            bool blnResult = false;
            if (ext == "gif" || ext == "jpg" || ext == "jpeg" || ext == "png")
            {
                blnResult = true;
            }
            else
            {
                blnResult = false;
            }
            return blnResult;
        }
        #endregion

        #region 파일 다운로드 기능
        /// <summary>
        /// 파일 다운로드 기능
        /// 주의 : 각 필드에 NULL 값이 들어가면 에러남
        /// </summary>
        public static string FuncFileDownSingle(int id, string strFileName, string strFileSize)
        {
            if (strFileName.Length > 0)
            {
                return "<a href=\"/DotNetNote/BoardDown.aspx?Id="
                    + id.ToString() + "\">"
                    + DownloadType(strFileName, strFileName + "("
                    + ConvertToFileSize(Convert.ToInt32(strFileSize)) + ")")
                    + "</a>";
            }
            else
            {
                return "-";
            }
        }
        public static string FuncFileDownSingle(int id, string strFileName, string strFileSize, string folder)
        {
            if (strFileName.Length > 0)
            {
                return "<a href=\"/" + folder + "/BoardDown.aspx?Id="
                    + id.ToString() + "\">"
                    + DownloadType(strFileName, strFileName + "("
                    + ConvertToFileSize(Convert.ToInt32(strFileSize)) + ")")
                    + "</a>";
            }
            else
            {
                return "-";
            }
        }
        public static string FuncFileDownSingle(int id, string strFileName, string strFileSize, string folder, string file)
        {
            if (strFileName.Length > 0)
            {
                return "<a href=\"/" + folder + "" + file + "?Id="
                    + id.ToString() + "\">"
                    + DownloadType(strFileName, strFileName + "("
                    + ConvertToFileSize(Convert.ToInt32(strFileSize)) + ")")
                    + "</a>";
            }
            else
            {
                return "-";
            }
        }
        #endregion

        #region DownloadType() 함수
        /// <summary>
        /// 다운로드할 파일의 확장자를 통해 아이콘을 결정. 
        /// </summary>
        /// <param name="strFileName">파일 이름</param>
        /// <param name="altString">alt 메세지로 넣을 문자열</param>
        public static string DownloadType(string strFileName, string altString, string imgUrl = "/images/ext/")
        {
            string strFileExt =
                Path.GetExtension(strFileName).Replace(".", "").ToLower();
            string r = "";
            switch (strFileExt)
            {
                case "ace":
                    r = "<img src='" + imgUrl + "ext_ace.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "ai":
                    r = "<img src='" + imgUrl + "ext_ai.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "alz":
                    r = "<img src='" + imgUrl + "ext_alz.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "arj":
                    r = "<img src='" + imgUrl + "ext_arj.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "asa":
                    r = "<img src='" + imgUrl + "ext_asa.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "asax":
                    r = "<img src='" + imgUrl + "ext_asax.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "ascx":
                    r = "<img src='" + imgUrl + "ext_ascx.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "asf":
                    r = "<img src='" + imgUrl + "ext_asf.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "asmx":
                    r = "<img src='" + imgUrl + "ext_asmx.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "asp":
                    r = "<img src='" + imgUrl + "ext_asp.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "aspx":
                    r = "<img src='" + imgUrl + "ext_aspx.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "asx":
                    r = "<img src='" + imgUrl + "ext_asx.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "au":
                    r = "<img src='" + imgUrl + "ext_au.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "avi":
                    r = "<img src='" + imgUrl + "ext_avi.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "bat":
                    r = "<img src='" + imgUrl + "ext_bat.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "bmp":
                    r = "<img src='" + imgUrl + "ext_bmp.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "c":
                    r = "<img src='" + imgUrl + "ext_c.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "cs":
                    r = "<img src='" + imgUrl + "ext_cs.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "csproj":
                    r = "<img src='" + imgUrl + "ext_csproj.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "cab":
                    r = "<img src='" + imgUrl + "ext_cab.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "chm":
                    r = "<img src='" + imgUrl + "ext_chm.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "com":
                    r = "<img src='" + imgUrl + "ext_com.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "config":
                    r = "<img src='" + imgUrl + "ext_config.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "cpp":
                    r = "<img src='" + imgUrl + "ext_cpp.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "css":
                    r = "<img src='" + imgUrl + "ext_css.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "csv":
                    r = "<img src='" + imgUrl + "ext_csv.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "disco":
                    r = "<img src='" + imgUrl + "ext_disco.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "dll":
                    r = "<img src='" + imgUrl + "ext_dll.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "doc":
                    r = "<img src='" + imgUrl + "ext_doc.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "docx":
                    r = "<img src='" + imgUrl + "ext_doc.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "eml":
                    r = "<img src='" + imgUrl + "ext_eml.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "exe":
                    r = "<img src='" + imgUrl + "ext_exe.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "gif":
                    r = "<img src='" + imgUrl + "ext_gif.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "gz":
                    r = "<img src='" + imgUrl + "ext_gz.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "h":
                    r = "<img src='" + imgUrl + "ext_h.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "hlp":
                    r = "<img src='" + imgUrl + "ext_hlp.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "htm":
                    r = "<img src='" + imgUrl + "ext_htm.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "html":
                    r = "<img src='" + imgUrl + "ext_html.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "hwp":
                    r = "<img src='" + imgUrl + "ext_hwp.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "hwt":
                    r = "<img src='" + imgUrl + "ext_hwt.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "inc":
                    r = "<img src='" + imgUrl + "ext_inc.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "ini":
                    r = "<img src='" + imgUrl + "ext_ini.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "jpg":
                    r = "<img src='" + imgUrl + "ext_jpg.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "jpeg":
                    r = "<img src='" + imgUrl + "ext_jpeg.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "js":
                    r = "<img src='" + imgUrl + "ext_js.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "lzh":
                    r = "<img src='" + imgUrl + "ext_lzh.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "m3u":
                    r = "<img src='" + imgUrl + "ext_m3u.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "max":
                    r = "<img src='" + imgUrl + "ext_max.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "mdb":
                    r = "<img src='" + imgUrl + "ext_mdb.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "mid":
                    r = "<img src='" + imgUrl + "ext_mid.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "mov":
                    r = "<img src='" + imgUrl + "ext_mov.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "mp2":
                    r = "<img src='" + imgUrl + "ext_mp2.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "mp3":
                    r = "<img src='" + imgUrl + "ext_mp3.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "mpe":
                    r = "<img src='" + imgUrl + "ext_mpe.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "mpeg":
                    r = "<img src='" + imgUrl + "ext_mpeg.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "mpg":
                    r = "<img src='" + imgUrl + "ext_mpg.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "msi":
                    r = "<img src='" + imgUrl + "ext_exe.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "":
                    r = "<img src='" + imgUrl + "ext_none.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "pcx":
                    r = "<img src='" + imgUrl + "ext_pcx.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "pdb":
                    r = "<img src='" + imgUrl + "ext_pdb.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "pdf":
                    r = "<img src='" + imgUrl + "ext_pdf.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "pls":
                    r = "<img src='" + imgUrl + "ext_pls.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "png":
                    r = "<img src='" + imgUrl + "ext_png.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "ppt":
                    r = "<img src='" + imgUrl + "ext_ppt.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "pptx":
                    r = "<img src='" + imgUrl + "ext_ppt.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "psd":
                    r = "<img src='" + imgUrl + "ext_psd.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "ra":
                    r = "<img src='" + imgUrl + "ext_ra.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "ram":
                    r = "<img src='" + imgUrl + "ext_ram.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "rar":
                    r = "<img src='" + imgUrl + "ext_rar.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "reg":
                    r = "<img src='" + imgUrl + "ext_reg.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "resx":
                    r = "<img src='" + imgUrl + "ext_resx.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "rm":
                    r = "<img src='" + imgUrl + "ext_rm.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "rmi":
                    r = "<img src='" + imgUrl + "ext_rmi.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "rtf":
                    r = "<img src='" + imgUrl + "ext_rtf.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "sql":
                    r = "<img src='" + imgUrl + "ext_sql.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "swf":
                    r = "<img src='" + imgUrl + "ext_swf.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "sys":
                    r = "<img src='" + imgUrl + "ext_sys.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "tar":
                    r = "<img src='" + imgUrl + "ext_tar.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "tga":
                    r = "<img src='" + imgUrl + "ext_tga.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "tif":
                    r = "<img src='" + imgUrl + "ext_tif.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "ttf":
                    r = "<img src='" + imgUrl + "ext_ttf.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "txt":
                    r = "<img src='" + imgUrl + "ext_txt.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "vb":
                    r = "<img src='" + imgUrl + "ext_vb.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "vbs":
                    r = "<img src='" + imgUrl + "ext_vbs.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "vbdisco":
                    r = "<img src='" + imgUrl + "ext_vbdisco.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "wav":
                    r = "<img src='" + imgUrl + "ext_wav.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "wax":
                    r = "<img src='" + imgUrl + "ext_wax.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "webinfo":
                    r = "<img src='" + imgUrl + "ext_webinfo.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "wma":
                    r = "<img src='" + imgUrl + "ext_wma.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "wmv":
                    r = "<img src='" + imgUrl + "ext_wmv.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "wmx":
                    r = "<img src='" + imgUrl + "ext_wmx.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "wri":
                    r = "<img src='" + imgUrl + "ext_wri.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "wvx":
                    r = "<img src='" + imgUrl + "ext_wvx.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "xls":
                    r = "<img src='" + imgUrl + "ext_xls.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "xlsx":
                    r = "<img src='" + imgUrl + "ext_xls.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "xml":
                    r = "<img src='" + imgUrl + "ext_xml.gif' border='0' alt='"
                        + altString + "'>"; break;
                case "zip":
                    r = "<img src='" + imgUrl + "ext_zip.gif' border='0' alt='"
                        + altString + "'>"; break;
                default:
                    r = "<img src='" + imgUrl + "ext_unknown.gif' border='0' alt='"
                        + altString + "'>"; break;
            }
            return r;
        }
        #endregion

        #region 댓글 개수를 표현하는 메서드: 순수 텍스트로만 표시 
        /// <summary>
        /// 댓글 개수를 표현하는 메서드: 순수 텍스트로만 표시 
        /// </summary>
        public static string ShowCommentCountOnlyText(object objCommentCount)
        {
            string strTemp = "";
            try
            {
                if (Convert.ToInt32(objCommentCount) > 0)
                {
                    strTemp = "<span style=\"font-size:8pt;\">" + objCommentCount.ToString() + "</span>";
                }
            }
            catch (Exception)
            {
                strTemp = "";
            }
            return strTemp;
        }
        #endregion

        #region 24시간내에 올라온 글 new 이미지 표시하기 : Sprite 이미지로 표시
        public static string FuncNewSpriteImage(object strDate, string imgUrl = "/images/new.png")
        {
            if (strDate != null)
            {
                if (!String.IsNullOrEmpty(strDate.ToString()))
                {
                    DateTime originDate = Convert.ToDateTime(strDate);

                    TimeSpan objTs = DateTime.Now - originDate;
                    string newImage = "";
                    if (objTs.TotalMinutes < 360)
                    {
                        newImage = "<img src=\"" + imgUrl + "\" />";
                    }
                    else if (objTs.TotalMinutes < 1440)
                    {
                        newImage = "<img src=\"" + imgUrl + "\" />";
                    }
                    return newImage;
                }
            }
            return "";
        }
        #endregion
    }
}
