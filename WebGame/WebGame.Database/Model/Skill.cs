﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Database.Model
{
    public class Skill : BaseEntity
    {
        public string BaseStat { get; set; }
        public int Status { get; set; }
        public int Range { get; set; }
        public object Target { get; set; }
        public int RechargeTime { get; set; }
        public int CostActionPoints { get; set; }
        public int DamageRadius { get; set; }
    }
}
