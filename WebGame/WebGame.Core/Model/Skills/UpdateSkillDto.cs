using System;

namespace WebGame.Core.Model.Skills
{
    public class UpdateSkillDto
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
        /// Base Stat
        /// </summary>
        public string BaseStat { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// Range
        /// </summary>
        public int? Range { get; set; }

        /// <summary>
        /// TargetId
        /// </summary>
        public Guid? TargetId { get; set; }

        /// <summary>
        /// RechargeTime
        /// </summary>
        public int? RechargeTime { get; set; }

        /// <summary>
        /// Cost Action Points
        /// </summary>
        public int? CostActionPoints { get; set; }

        /// <summary>
        /// DamageRadius
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

        /// <summary>
        /// Race Id
        /// </summary>
        public Guid? RaceId { get; set; }

        /// <summary>
        /// Specialization Id
        /// </summary>
        public Guid? SpecializationId { get; set; }
    }
}
