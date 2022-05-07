using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CWTester.PasswordEncryptor
{
    public class Encryptor
    {
        public static string Encrypt(string input)
        {
            byte[] hash = Encoding.UTF8.GetBytes(input);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hashenc = md5.ComputeHash(hash);
            string output = "";
            foreach (var item in hashenc)
            {
                output += item.ToString();
            }
            return output;
        }
    }
}
