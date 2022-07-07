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
        public string Race { get; set; }
        public string HeroClass { get; set; }
        public string Skills { get; set; }
        public int Level { get; set; }

        public Guid HeadId { get; set; }
        public Guid BodyId { get; set; }
        public bool Sex { get; set; }

        public Guid WeaponId { get; set; }
        public Guid HelmetId { get; set; }
        public Guid SecondWeaponId { get; set; }


        public bool ShowHelmet { get; set; }
        public bool IsDeleted { get; set; }
    }
}
