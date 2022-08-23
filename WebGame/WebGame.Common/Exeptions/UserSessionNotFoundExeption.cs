using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Common.Exeptions
{
    public class UserSessionNotFoundExeption : BuisnessException
    {
        public UserSessionNotFoundExeption() { }

        public UserSessionNotFoundExeption(string message): base(message) { }
    }
}
