using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Core.Model
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
        /// Hero Head Id
        /// </summary>
        public int HeadId { get; set; }

        /// <summary>
        /// Hero Body Id
        /// </summary>
        public int BodyId { get; set; }

        /// <summary>
        /// Hero Sex 
        /// </summary>
        public bool Sex { get; set; }

        /// <summary>
        /// Hero Show Helmet
        /// </summary>
        public bool ShowHelmet { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Stats { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string History { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Armor { get; set; }
    }
}
