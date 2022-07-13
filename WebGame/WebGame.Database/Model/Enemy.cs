using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Database.Model
{
    public class Enemy : Character
    {
        public string Name { get; set; }
        public string ImagePng { get; set; }
        public bool IsRanged { get; set; }
        public List<Skill> Skills { get; set; }

    }
}
