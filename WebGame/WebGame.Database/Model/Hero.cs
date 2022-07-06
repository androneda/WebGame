using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Database.Model
{
    public class Hero
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int Level { get; set; }
        public int HeadId { get; set; }
        public int BodyId { get; set; }
        public int WeaponId { get; set; }

        public bool Sex { get; set; }

        public bool ShowHelmet { get; set; }
        public bool IsDeleted { get; set; }
    }
}
