﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebGame.Common
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // Потребитель токена
        const string KEY = "MySuperSecret_SecretKey123!"; // Ключ шифрации
        public const int LIFETIME = 5; // Время жизни токена - 5 мин
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
