using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Database.Model
{
    public class Specialization : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Skill> Skills { get; set; }

        public ICollection<Hero> Hero { get; set; }
    }
}
