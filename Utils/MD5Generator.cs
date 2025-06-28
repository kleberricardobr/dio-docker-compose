using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace desafio_web.Utils
{
    public class MD5Generator
    {
        //https://stackoverflow.com/questions/11454004/calculate-a-md5-hash-from-a-string
        public static string ToMD5(string text)
        {
            byte[] encodedPassword = new UTF8Encoding().GetBytes(text);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

            string encoded = BitConverter.ToString(hash)
               .Replace("-", string.Empty)
               .ToLower();

            return encoded;
        }
    }
}