using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using WebGame.Database.Model;

namespace WebGame.Database
{
    public class WebGameDBContext : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Ammunition> Ammunition { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Specialization> Specializations { get; set; }

        public WebGameDBContext([NotNull] DbContextOptions options) : base(options)
        {
     
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>(b =>
            {
                b.HasOne(p => p.Race);
                b.HasOne(p => p.Specialization);
            });
            //modelBuilder.Entity<Hero>()
            //.HasOne(s => s.RaceId)
            //.WithOne(ad => ad.Hero)
            //.HasForeignKey<Race>(ad => ad.Id);

            //modelBuilder.Entity<Hero>()
            //.HasOne(s => s.SpecializationId)
            //.WithOne(ad => ad.Hero)
            //.HasForeignKey<Specialization>(ad => ad.Id);
        }

    }
}
