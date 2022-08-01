using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Common.Exeptions
{
    public class AmmunitionNotFoundExeption : BaseException
    {
        public AmmunitionNotFoundExeption() { }

        public AmmunitionNotFoundExeption(string message): base(message) { }
    }
}
