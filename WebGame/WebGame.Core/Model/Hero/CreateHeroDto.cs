using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Race { get; set; }

        /// <summary>
        /// Hero Class
        /// </summary>
        public string HeroClass { get; set; }

    }
}
