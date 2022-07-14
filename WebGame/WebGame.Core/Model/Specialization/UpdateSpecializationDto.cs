using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Database.Model;

namespace WebGame.Core.Model.Specialization
{
    public class UpdateSpecializationDto
    {
        /// <summary>
        /// Specialization Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Specialization Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Specialization Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Specialization Skills
        /// </summary>
        public ICollection<Skill> Skills { get; set; }
    }
}
