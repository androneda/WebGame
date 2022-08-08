﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Core.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(string username, string password);
    }
}
