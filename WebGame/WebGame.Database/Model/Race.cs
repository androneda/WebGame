using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Database.Model
{
    public class Race : BaseEntity
    {
        public List<Skill> Skills { get; set; }
        public List<Stat> BonusStats { get; set; }
        public int BonusActionPoints { get; set; }
    }
}
