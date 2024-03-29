﻿using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Database.Repositories
{
    public class AmmunitionRepository : BaseRepository<Ammunition>, IAmmunitionRepository
    {
        public AmmunitionRepository(WebGameDBContext context) : base(context)
        {
        }
    }
}
