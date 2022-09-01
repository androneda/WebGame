using System;
using WebGame.Core.Model.Role;

namespace WebGame.Core.Model.User
{
    public class UserViewDto
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// User Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// User Role Id
        /// </summary>
        public Guid RoleId { get; set; }
        public RoleViewDto Role { get; set; }


    }
}
