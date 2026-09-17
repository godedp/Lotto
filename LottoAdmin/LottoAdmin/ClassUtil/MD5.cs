using System;
using System.Text;

namespace LottoAdmin.ClassUtil
{
    public class MD5
    {
        public string PasswordMD5(string password)
        {
            string text = "example";
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
               return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}
