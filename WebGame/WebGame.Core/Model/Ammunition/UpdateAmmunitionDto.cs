using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Core.Model.Ammunition
{
    public class UpdateAmmunitionDto
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
