using Microsoft.EntityFrameworkCore;
using final_project_it3045c.Models;

namespace final_project_it3045c.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TeamMember> TeamMembers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            // TODO: GET DATA TO SEED!!!!!!!!!!!!!! IT WON'T SEED!!!!!!!!
            modelBuilder.Entity<TeamMember>().HasData(
                new TeamMember { Id = 1, FullName = "Paul Sparks" }
                // Add more seed data as needed
            );
        }
    }
}
