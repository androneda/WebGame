using Microsoft.AspNetCore.Identity;

namespace Chat.Models
{
    public class User:IdentityUser
    {
        public int Year { get; set; }
    }
}
