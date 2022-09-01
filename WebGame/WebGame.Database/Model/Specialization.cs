using System.Collections.Generic;

namespace WebGame.Database.Model
{
    public class Specialization : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<Skill> Skills { get; set; }
        public ICollection<Hero> Hero { get; set; }
    }
}
