using Microsoft.EntityFrameworkCore;
using final_project_it3045c.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

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
        }

        // public void SeedDatabase() {
        //     Console.WriteLine("SeedDatabase Called!");
        //     var modelBuilder = new ModelBuilder(new ConventionSet());
        //     // TODO: GET DATA TO SEED!!!!!!!!!!!!!! IT WON'T SEED!!!!!!!!
        //     modelBuilder.Entity<TeamMember>().HasData(
        //         new TeamMember { Id = 1, FullName = "Paul Sparks" }
        //         // Add more seed data as needed
        //     );

        //     SaveChanges();
        // }
    }
}
