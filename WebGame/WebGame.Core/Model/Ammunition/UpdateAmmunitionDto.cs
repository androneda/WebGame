using System;

namespace WebGame.Core.Model.Ammunition
{
    public class UpdateAmmunitionDto
    {


        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Hero Specialization Id
        /// </summary>
        public Guid SpecializationId { get; set; }

        /// <summary>
        /// Hero Race Id
        /// </summary>
        public Guid RaceId { get; set; }

    }
}
