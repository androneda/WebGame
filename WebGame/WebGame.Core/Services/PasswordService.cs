using System;
using System.Security.Cryptography;
using System.Text;
using WebGame.Core.Services.Interfaces;

namespace WebGame.Core.Services
{
    public class PasswordService : IPasswordService
    {
        public string GenerateSaltedHash(string password)
        {
            byte[] coddedPassword = Encoding.UTF8.GetBytes(password);
            byte[] salt = new byte[] { 32, 12, 23, 23, 4 };
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[coddedPassword.Length + salt.Length];

            for (int i = 0; i < coddedPassword.Length; i++)
            {
                plainTextWithSaltBytes[i] = coddedPassword[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[coddedPassword.Length + i] = salt[i];
            }

            var hashed = algorithm.ComputeHash(plainTextWithSaltBytes);
            return Convert.ToBase64String(hashed);
        }
    }
}
