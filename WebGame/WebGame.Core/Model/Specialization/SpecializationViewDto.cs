using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Core.Model.Skills;
using WebGame.Database.Model;

namespace WebGame.Core.Model.Specialization
{
    public class SpecializationViewDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Skills
        /// </summary>
        public IEnumerable<SkillViewDto> Skills { get; set; }
    }
}
