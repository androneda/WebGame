using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Common.Exeptions
{
    public class UserNotFoundExeption : BaseException
    {
        public UserNotFoundExeption() { }

        public UserNotFoundExeption(string message): base(message) { }
    }
}
