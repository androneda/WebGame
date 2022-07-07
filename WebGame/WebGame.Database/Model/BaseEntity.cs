using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Database.Model
{
    public class BaseEntity
    {
        public Guid Id { get; set; } 
        public bool IsDeleted { get; set; }
    }
}
