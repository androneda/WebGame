using System;

namespace WebGame.Database.Model
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
