using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Core.Model.Skill
{
    public class ShortSkillViewDto
    {

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string BaseStat { get; set; }

        /// <summary>
        /// Race
        /// </summary>
        public int? RechargeTime { get; set; }

        /// <summary>
        /// Hero Class
        /// </summary>
        public int? CostActionPoints { get; set; }

        /// <summary>
        /// Hero Show Helmet
        /// </summary>
        public int? BonusActionPoints { get; set; }

        /// <summary>
        /// Hero Show Helmet
        /// </summary>
        public bool? IsOnAlly { get; set; }

    }
}
