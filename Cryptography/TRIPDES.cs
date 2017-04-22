using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    public class TRIPDES
    {
        public static string Encrypt(string input)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(input);
            var hash = new MD5CryptoServiceProvider();
            keyArray = hash.ComputeHash(Encoding.UTF8.GetBytes("freepay"));
            var tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        // Verify a hash against a string.
        public static string Decrypt(string hash)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(hash);
            var sha1Hash = new MD5CryptoServiceProvider();
            keyArray = sha1Hash.ComputeHash(Encoding.UTF8.GetBytes("freepay"));
            var tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Encoding.UTF8.GetString(resultArray);
        }
    }
}
