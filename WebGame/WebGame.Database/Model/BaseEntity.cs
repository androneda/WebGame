using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Database.Model
{
    public class BaseEntity
    {
        public Guid Id { get; set; } // тут вообще? надо какие то обобщенности пихать?
        public string Name { get; set; }
        public string Race { get; set; }
        public string HeroClass { get; set; }
    }
}
