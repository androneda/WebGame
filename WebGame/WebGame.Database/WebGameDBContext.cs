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
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Session> UserSessions { get; set; }

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

            modelBuilder.Entity<User>(b =>
            {
                b.HasOne(p => p.Role);
            });

            modelBuilder.Entity<Session>(b =>
            {
                b.HasOne(p => p.User);
            });

            //modelBuilder.Entity<Race>(b =>
            //{
            //    b.HasMany(p => p.Skills);
            //});

            //modelBuilder.Entity<Specialization>(b =>
            //{
            //    b.HasMany(p => p.Skills);
            //});

        }

    }
}
