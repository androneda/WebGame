using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Common.Exeptions
{
    public class RaceNotFoundExeption : BuisnessException
    {
        public RaceNotFoundExeption() { }

        public RaceNotFoundExeption(string message): base(message) { }
    }
}
