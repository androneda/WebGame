using System;

namespace WebGame.Core.Model.Hero
{
    public class HeroViewDto
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
        /// Hero Race Id
        /// </summary>
        public Guid RaceId { get; set; }

        /// <summary>
        /// Hero Specialization Id
        /// </summary>
        public Guid SpecializationId { get; set; }

        /// <summary>
        /// Hero Head Id
        /// </summary>
        public Guid HeadId { get; set; }

        /// <summary>
        /// Hero Body Id
        /// </summary>
        public Guid BodyId { get; set; }

        /// <summary>
        /// Hero Sex 
        /// </summary>
        public bool Sex { get; set; }

        /// <summary>
        /// Hero Show Helmet
        /// </summary>
        public bool ShowHelmet { get; set; }
    }
}
