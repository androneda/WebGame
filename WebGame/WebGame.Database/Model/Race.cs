using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Common.Enums;

namespace WebGame.Database.Model
{
    public class Race : BaseEntity
    {
        //public List<Stat> BonusStats { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<Hero> Hero { get; set; }

    }
}
