using System;
using System.Collections.Generic;
using WebGame.Core.Model.Skills;

namespace WebGame.Core.Model.Races
{
    public class RaceViewDto
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
