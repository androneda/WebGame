using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Core.Model.Skills;

namespace WebGame.Core.Model.Races
{
    public class RaceViewDto
    {
        /// <summary>
        /// Name
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Description{ get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public ICollection<SkillViewDto> Skills { get; set; }
    }
}
