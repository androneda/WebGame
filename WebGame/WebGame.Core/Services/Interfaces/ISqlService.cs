using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebGame.Core.Model.Hero;

namespace WebGame.Core.Services.Interfaces
{
    public interface ISqlService
    {
        Task<string> GetSql(string query);
    }
}
