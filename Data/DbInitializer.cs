using Microsoft.EntityFrameworkCore;
using final_project_it3045c.Models;

namespace final_project_it3045c.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext dbContext, bool isCleared)
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

            var memberDetailsSet = new List<MemberDetails>
            {
                new() {
                    TeamMember = teamMembers.First(),
                    FavoriteFood = "Pad Thai",
                    FavoriteColor = "Black",
                    Age = 19,
                    FavoriteTVShow = "Breaking Bad",
                    FavoriteDrink = "Water"
                }
            };

            dbContext.TeamMembers.AddRange(teamMembers);
            dbContext.MemberDetailsSet.AddRange(memberDetailsSet);

            dbContext.SaveChanges();
        }

        private static void ClearData(AppDbContext dbContext)
        {
            // Reset identity to 1
            dbContext.Database.ExecuteSqlRaw("DBCC CHECKIDENT('dbo.TeamMembers', RESEED, 0)");
            dbContext.Database.ExecuteSqlRaw("DBCC CHECKIDENT('dbo.MemberDetailsSet', RESEED, 0)");

            // Delete all records
            dbContext.TeamMembers.RemoveRange(dbContext.TeamMembers);
            dbContext.MemberDetailsSet.RemoveRange(dbContext.MemberDetailsSet);

            dbContext.SaveChanges();
        }

    }

}
