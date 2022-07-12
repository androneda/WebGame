﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Database.Model
{
    public class Hero : Character
    {
        public string Race { get; set; }
        public string Specialization { get; set; }
        public int Level { get; set; }
        public int ActionPoints { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Stat> Stats { get; set; }

        public Guid HeadId { get; set; }
        public Guid BodyId { get; set; }
        public bool Sex { get; set; }

        public Guid WeaponId { get; set; }
        public Guid HelmetId { get; set; }
        public Guid SecondWeaponId { get; set; }

        public bool ShowHelmet { get; set; }
    }
}
