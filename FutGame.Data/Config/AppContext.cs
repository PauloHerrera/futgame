using System.Data.Entity;
using FutGame.Model.Entities;

namespace FutGame.Data.Config
{
    public class AppContext : DbContext
    {
        public AppContext()
            : base("Default")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolDBContext, SchoolDataLayer.Migrations.Configuration>("SchoolDBConnectionString"));
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                   .HasMany<Player>(s => s.Players)
                   .WithMany(c => c.Teams)
                   .Map(cs =>
                   {
                       cs.MapLeftKey("TeamId");
                       cs.MapRightKey("PlayerId");
                       cs.ToTable("TeamPlayers");
                   });
        }
    }
}
