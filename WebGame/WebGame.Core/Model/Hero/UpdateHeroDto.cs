﻿using System;

namespace WebGame.Core.Model.Hero
{
    public class UpdateHeroDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public Guid RaceId { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public Guid SpecializationId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Head Id
        /// </summary>
        public Guid HeadId { get; set; }

        /// <summary>
        /// Body Id
        /// </summary>
        public Guid BodyId { get; set; }

        /// <summary>
        /// Sex 
        /// </summary>
        public bool Sex { get; set; }

        /// <summary>
        /// Show Helmet
        /// </summary>
        public bool ShowHelmet { get; set; }
    }
}
