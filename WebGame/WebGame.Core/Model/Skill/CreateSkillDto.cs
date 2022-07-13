using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Common.Enums;

namespace WebGame.Core.Model.Skill
{
    public class CreateSkillDto
    {

        /// <summary>
        /// Skil Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Skil Race
        /// </summary>
        public Guid? Race { get; set; }

        /// <summary>
        /// Skil Class
        /// </summary>
        public Guid? Specialization { get; set; }

        /// <summary>
        /// Skil BaseStat
        /// </summary>
        public string BaseStat { get; set; }

        /// <summary>
        /// Skil Range
        /// </summary>
        public int? Range { get; set; }

        /// <summary>
        /// Skil RechargeTime
        /// </summary>
        public int RechargeTime { get; set; }

        /// <summary>
        /// Skil CostActionPoints
        /// </summary>
        public int CostActionPoints { get; set; }

        /// <summary>
        /// Skil DamageRadius
        /// </summary>
        public int? DamageRadius { get; set; }

        /// <summary>
        /// Skil BonusActionPoints
        /// </summary>
        public int? BonusActionPoints { get; set; }

        /// <summary>
        /// Skil IsOnAlly
        /// </summary>
        public bool? IsOnAlly { get; set; }

    }
}
