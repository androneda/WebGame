using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebGame.Api
{
    public class JwtOptions
    {
        public string ISSUER { get; set; } // издатель токена
        public  string AUDIENCE { get; set; } // Потребитель токена
        public string KEY { get; set; } // Ключ шифрации
        public  int LIFETIME { get; set; } // Время жизни токена - 5 мин
    }
}
