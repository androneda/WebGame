using System.Diagnostics.CodeAnalysis;
using WebGame.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace WebGame.Database
{
    public class WebGameDBContext : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Ammunition> Ammunition { get; set; }

        public WebGameDBContext([NotNull] DbContextOptions options) : base(options) 
        {
            Database.EnsureCreated();
        }

    }
}
