using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Database.Model
{
    public class WebGameDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public WebGameDBContext()
        {
            Database.EnsureCreated();
        }
        public WebGameDBContext([NotNull] DbContextOptions options) : base(options) 
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=WebGameDB;Username=postgres;Password=postgres");
        }
    }
}
