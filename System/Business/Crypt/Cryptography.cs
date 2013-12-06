using System;
using System.Security.Cryptography;

namespace Business.Crypt
{
    internal sealed class Cryptography
    {
        public String Encode(String toEncode)
        {
            Byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new Byte[28]);
            var passwordBytes = new Rfc2898DeriveBytes(toEncode, salt, 1001);
            Byte[] hashedPassword = passwordBytes.GetBytes(20);
            var combinedWithSalt = new Byte[48];
            Array.Copy(salt, 0, combinedWithSalt, 0, 28);
            Array.Copy(hashedPassword, 0, combinedWithSalt, 28, 20);
            return Convert.ToBase64String(combinedWithSalt);
        }

        public Boolean Compare(String compareWith, String toCompare)
        {
            Byte[] dbPassword = Convert.FromBase64String(compareWith);
            var salt = new Byte[28];
            Array.Copy(dbPassword, 0, salt, 0, 28);

            var userPasswordBytes = new Rfc2898DeriveBytes(toCompare, salt, 1001);
            Byte[] userPasswordHash = userPasswordBytes.GetBytes(20);

            for (Int32 i = 0; i < 20; i++)
            {
                if (dbPassword[i + 28] != userPasswordHash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
