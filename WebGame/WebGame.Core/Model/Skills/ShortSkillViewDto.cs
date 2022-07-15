using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Core.Model.Skills
{
    public class ShortSkillViewDto
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Base Stat
        /// </summary>
        public string BaseStat { get; set; }

        /// <summary>
        /// Recharge Time
        /// </summary>
        public int? RechargeTime { get; set; }

        /// <summary>
        /// Cost Action Points
        /// </summary>
        public int? CostActionPoints { get; set; }

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
