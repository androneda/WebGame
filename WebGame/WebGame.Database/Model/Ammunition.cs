using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Database.Model
{
    public class Ammunition : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public Guid RaceId { get; set; }
        public Guid SpecializationId { get; set; }

    }
}
