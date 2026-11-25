using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordHasherLib
{
    public class PasswordHasher
    {
        public static string GetSha256Hash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] sourceBytePassw = Encoding.UTF8.GetBytes(password);

                byte[] hashSourceBytePassw = sha256Hash.ComputeHash(sourceBytePassw);

                string hashPassw = BitConverter.ToString(hashSourceBytePassw).Replace("-", String.Empty);

                return hashPassw;
            }
        }
    }
}