using Microsoft.EntityFrameworkCore;
using final_project_it3045c.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace final_project_it3045c.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext dbContext, Boolean isCleared)
        {
            if (isCleared) {
                ClearData(dbContext);
            }

            SeedData(dbContext); 
        }

        private static void SeedData (AppDbContext dbContext) {
            // Check if the database has already been seeded
            if (dbContext.TeamMembers.Any())
            {
                return; // Database has been seeded
            }

            // Seed data for TeamMembers
            var teamMembers = new List<TeamMember>
            {
                new() {
                    FullName = "Paul Sparks",
                    BirthDate = new DateTime(new DateOnly(2004, 4, 12), new TimeOnly(0)),
                    CollegeProgram = "Information Technology",
                    YearInProgram = "Sophomore"
                },
                // Add more seed data as needed
            };

            dbContext.TeamMembers.AddRange(teamMembers);
            dbContext.SaveChanges();
        }

        private static void ClearData(AppDbContext dbContext)
        {
            // Reset identity to 1
            dbContext.Database.ExecuteSqlRaw("DBCC CHECKIDENT('dbo.TeamMembers', RESEED, 0)");

            // Delete all records from TeamMembers table
            dbContext.TeamMembers.RemoveRange(dbContext.TeamMembers);
            dbContext.SaveChanges();
        }

    }

}
