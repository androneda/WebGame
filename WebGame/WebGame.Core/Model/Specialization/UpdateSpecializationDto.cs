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
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public ICollection<Skill> Skills { get; set; }
    }
}
