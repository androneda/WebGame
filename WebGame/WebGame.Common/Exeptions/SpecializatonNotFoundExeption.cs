﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Common.Exeptions
{
    public class SpecializationNotFoundExeption : BaseException
    {
        public SpecializationNotFoundExeption() { }

        public SpecializationNotFoundExeption(string message)
            : base(message) { }
    }
}