using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Database.Model
{
    public class UserSession:BaseEntity
    {
        public UserSession(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }
        public User User { get; set; }
        public Role UserRole { get; set; }
    }
}
