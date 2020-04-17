using Dul.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Dul.Tests
{
    [TestClass]
    public class CryptorEngineTest
    {
        [TestMethod]
        public void EncryptTest()
        {
            CryptorEngine cryptor = new CryptorEngine();

            string password = "1234";
            string encrypted = cryptor.Encrypt(password, true);
            Console.WriteLine(encrypted); // ????
            string decrypted = cryptor.Decrypt(encrypted, true);
            Console.WriteLine(decrypted); // 1234

            Console.WriteLine(cryptor.EncryptPassword("1234")); // ????
        }
    }
}
