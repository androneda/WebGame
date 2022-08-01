﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Database.Repositories
{
    public class RaceRepository:BaseRepository<Race>, IRaceRepository
    {
        public RaceRepository(WebGameDBContext context) : base(context)
        {

        }
    }
}