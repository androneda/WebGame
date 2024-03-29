﻿using System;

namespace WebGame.Core.Model.Hero
{
    public class CreateHeroDto
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Race
        /// </summary>
        public Guid RaceId { get; set; }

        /// <summary>
        /// Hero Class
        /// </summary>
        public Guid SpecializationId { get; set; }
    }
}
