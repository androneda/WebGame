using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Common.Exeptions
{
    public class BuisnessException : Exception
    {
        public BuisnessException() { }
        public BuisnessException(string message) : base(message)
        {
        }
    }
}
