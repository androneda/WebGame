using System;

namespace WebGame.Core.Model.User
{
    public class CreateUserDto
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
        /// Role
        /// </summary>
        public Guid RoleId { get; set; }
    }
}
