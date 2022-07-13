using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Common.Exeptions
{
    public class SkillNotFoundExeption : Exception
    {
        public SkillNotFoundExeption() { }

        public SkillNotFoundExeption(string message)
            : base(message) { }
    }
}
