using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Core.Model.Skill
{
    public class UpdateSkillDto
    {
        /// <summary>
        /// Skill Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Skill BaseStat
        /// </summary>
        public string BaseStat { get; set; }

        /// <summary>
        /// Skill Status
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// Skill Range
        /// </summary>
        public int? Range { get; set; }

        /// <summary>
        /// Skill TargetId
        /// </summary>
        public Guid? TargetId { get; set; }

        /// <summary>
        /// Skill RechargeTime
        /// </summary>
        public int? RechargeTime { get; set; }

        /// <summary>
        /// Skill CostActionPoints
        /// </summary>
        public int? CostActionPoints { get; set; }

        /// <summary>
        /// Skill DamageRadius
        /// </summary>
        public int? DamageRadius { get; set; }

        /// <summary>
        /// Skill BonusActionPoints
        /// </summary>
        public int? BonusActionPoints { get; set; }

        /// <summary>
        /// Skill IsOnAlly
        /// </summary>
        public bool? IsOnAlly { get; set; }


        /// <summary>
        /// Skill RaceId
        /// </summary>
        public Guid? RaceId { get; set; }

        /// <summary>
        /// Skill SpecializationId
        /// </summary>
        public Guid? SpecializationId { get; set; }

    }
}
