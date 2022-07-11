using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Common.Exeptions
{
    public class HeroNotFoundExeption : Exception
    {
        public HeroNotFoundExeption() { }

        public HeroNotFoundExeption(string message)
            : base(message) { }
    }
}
