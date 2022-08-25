using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Common.Exeptions
{
    public class SessionNotFoundExeption : BuisnessException
    {
        public SessionNotFoundExeption() { }

        public SessionNotFoundExeption(string message): base(message) { }
    }
}
