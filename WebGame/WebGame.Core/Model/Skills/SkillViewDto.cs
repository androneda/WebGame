using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Core.Model.Skills
{
    public class SkillViewDto
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Skill Race
        /// </summary>
        public Guid RaceId { get; set; }

        /// <summary>
        /// Skill Specialization
        /// </summary>
        public Guid SpecializationId { get; set; }

        /// <summary>
        /// Skill Range
        /// </summary>
        public int Range { get; set; }

        /// <summary>
        /// Skill Recharge Time
        /// </summary>
        public int RechargeTime { get; set; }

        /// <summary>
        /// Skill Hero Cost Action Points 
        /// </summary>
        public int CostActionPoints { get; set; }

        /// <summary>
        /// Skill Damage Radius
        /// </summary>
        public int? DamageRadius { get; set; }

        /// <summary>
        /// Skill Bonus Action Points
        /// </summary>
        public int? BonusActionPoints { get; set; }

        /// <summary>
        /// Skill Is On Ally
        /// </summary>
        public bool? IsOnAlly { get; set; }

    }
}
