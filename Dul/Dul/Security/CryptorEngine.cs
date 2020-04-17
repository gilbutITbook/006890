using System;
using System.Security.Cryptography;
using System.Text;

namespace Dul.Security
{
    /// <summary>
    /// 암호 엔진
    /// </summary>
    public class CryptorEngine
    {
        private readonly string _key;

        public CryptorEngine()
        {
            _key = "Dul";
        }
        public CryptorEngine(string key)
        {
            this._key = key;
        }

        /// <summary>
        /// 이중 암호화 방법을 사용하여 문자열을 암호화합니다. 암호화 된 암호 텍스트를 돌려줍니다.
        /// </summary>
        /// <param name="toEncrypt">암호화 할 문자열</param>
        /// <param name="useHashing">해시를 사용하시겠습니까? 추가 보안 관련 클래스를 사용합니다.</param>
        public string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
                        
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(_key));
                hashmd5.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(_key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// 이중 암호화 방법을 사용하여 암호화된 문자열의 암호화를 해제합니다.
        /// </summary>
        /// <param name="cipherString">암호화 된 문자열</param>
        /// <param name="useHashing">이 데이터를 암호화하기 위해 해싱을 사용했습니까? true or false를 설정합니다.</param>
        public string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(_key));
                hashmd5.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(_key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();

            byte[] resultArray = new byte[toEncryptArray.Length];

            try
            {
                resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            }
            catch
            {
                resultArray = new byte[0];  // 잘못된 암호화 데이터가 들어가 있을경우 강제로 값 할당
            }

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        /// <summary>
        /// 단방향 암호화: 복호화 불가능
        /// </summary>
        public string EncryptPassword(string password)
        {
            return SHA256Hash(MD5Hash(password)); 
        }

        /// <summary>
        /// MD5 암호화(128 Bit 암호화)
        /// </summary>
        private string MD5Hash(string Data)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(Data));

            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hash)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// SHA256 암호화( 256 Bit 암호화)
        /// </summary>
        private string SHA256Hash(string Data)
        {
            SHA256 sha = new SHA256Managed();

            byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(Data));

            StringBuilder stringBuilder = new StringBuilder();

            foreach (byte b in hash)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }

            return stringBuilder.ToString();
        }
    }
}
