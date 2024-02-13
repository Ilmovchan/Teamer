using Microsoft.EntityFrameworkCore;
using Teamer.DATA.Migrations;
using Teamer.DATA.Models;

namespace Teamer.DATA.Repository
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TeamUser> TeamUsers { get; set; }

        public string DbPath { get; }

        public DataContext()
        {
            DbPath = "TeamerDb";
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamUser>()
                .HasKey(tu => new { tu.TeamId, tu.UserId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
