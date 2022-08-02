using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Chat
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // Потребитель токена
        const string KEY = "MySuperSecret_SecretKey123!"; // Ключ шифрации
        public const int LIFETIME = 1; // Время жизни токена - 1 мин
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
