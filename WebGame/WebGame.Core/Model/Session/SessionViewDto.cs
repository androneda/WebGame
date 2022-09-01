using System;

namespace WebGame.Core.Model.Session
{
    public class SessionViewDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public bool IsActive { get; set; }
    }
}
