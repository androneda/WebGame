using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Database.Model
{
    public class Ammunition
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string HeroClass { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public bool IsDeleted { get; set; }
    }
}
