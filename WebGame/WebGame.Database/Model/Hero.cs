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

        public string HeadId { get; set; }
        public string BodyId { get; set; }
        public bool Sex { get; set; }
    }
}
