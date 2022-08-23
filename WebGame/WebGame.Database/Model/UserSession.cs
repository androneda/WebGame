using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Database.Model
{
    public class UserSession:BaseEntity
    {
        public UserSession()
        {

        }
        public UserSession(Guid userId, Guid roleId)
        {
            IsActive = true;
            UserId = userId;
            UserRoleId = roleId;
        }

        public bool IsActive { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid UserRoleId { get; set; }
        public Role UserRole { get; set; }
    }
}
