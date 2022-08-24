﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Database.Repositories
{
    public class UserSessionRepository : BaseRepository<Session>, ISessionRepository
    {
        public UserSessionRepository(WebGameDBContext context) : base (context)  
        {

        }
    }
}
