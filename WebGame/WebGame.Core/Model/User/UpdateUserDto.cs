using System;

namespace WebGame.Core.Model.User
{
    public class UpdateUserDto
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
        /// Role Id
        /// </summary>
        public Guid RoleId { get; set; }

    }
}
