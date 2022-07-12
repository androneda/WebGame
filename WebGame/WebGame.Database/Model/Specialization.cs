using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Database.Model
{
    public class Specialization : BaseEntity
    {
        public List<Skill> Skills { get; set; }
    }
}
