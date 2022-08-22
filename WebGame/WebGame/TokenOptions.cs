using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebGame
{
    public class TokenOptions
    {
        public const string Token = "Token";

        public string ISSUER { get; set; } // издатель токена
        public string AUDIENCE { get; set; } // Потребитель токена
        public static string KEY { get; set; } // Ключ шифрации
        public int LIFETIME { get; set; } // Время жизни токена - 1 мин

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
