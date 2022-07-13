using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Database.Model
{
    public class Event : BaseEntity
    {
        public string Name { get; set; }
        //событие с особой наградой. раз в n дней
    }
}
