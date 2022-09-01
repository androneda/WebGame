using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Common.Exeptions
{
    public class CustomArgumentException:BuisnessException
    {
        public CustomArgumentException() { }

        public CustomArgumentException(string message) : base(message) { }
    }
}
