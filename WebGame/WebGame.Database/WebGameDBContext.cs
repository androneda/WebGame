using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace WebGame.Database
{
    public class WebGameDBContext : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }

        public WebGameDBContext([NotNull] DbContextOptions options) : base(options) 
        {
            Database.EnsureCreated();
        }

    }
}
