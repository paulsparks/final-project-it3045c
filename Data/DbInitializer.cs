using Microsoft.EntityFrameworkCore;
using final_project_it3045c.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace final_project_it3045c.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext dbContext)
        {
            // Check if the database has already been seeded
            if (dbContext.TeamMembers.Any())
            {
                return; // Database has been seeded
            }

            // Seed data for TeamMembers
            var teamMembers = new List<TeamMember>
            {
                new() { FullName = "Paul Sparks" },
                // Add more seed data as needed
            };

            dbContext.TeamMembers.AddRange(teamMembers);
            dbContext.SaveChanges();
        }
    }

}
