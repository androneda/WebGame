using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Common.Enums;

namespace WebGame.Core.Model.Skills
{
    public class CreateSkillDto
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Race Id
        /// </summary>
        public Guid? RaceId { get; set; }

        /// <summary>
        /// Specialization Id
        /// </summary>
        public Guid? SpecializationId { get; set; }

        /// <summary>
        /// Base Stat
        /// </summary>
        public string BaseStat { get; set; }

        /// <summary>
        /// Range
        /// </summary>
        public int? Range { get; set; }

        /// <summary>
        /// Recharge Time
        /// </summary>
        public int RechargeTime { get; set; }

        /// <summary>
        /// Cost Action Points
        /// </summary>
        public int CostActionPoints { get; set; }

        /// <summary>
        /// Damage Radius
        /// </summary>
        public int? DamageRadius { get; set; }

        /// <summary>
        /// Bonus Action Points
        /// </summary>
        public int? BonusActionPoints { get; set; }

        /// <summary>
        /// Is On Ally
        /// </summary>
        public bool? IsOnAlly { get; set; }
    }
}
