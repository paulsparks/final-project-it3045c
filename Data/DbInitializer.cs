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
            if (!dbContext.TeamMembers.Any() && !dbContext.MemberDetailsSet.Any())
            {
                // Seed data for TeamMembers
                var teamMembers = new List<TeamMember>
                {
                    new() {
                        FullName = "Paul Sparks",
                        BirthDate = new DateTime(new DateOnly(2004, 4, 12), new TimeOnly(0)),
                        CollegeProgram = "Information Technology",
                        YearInProgram = "Sophomore"
                    },
                    new() {
                        FullName = "Drake Damron",
                        BirthDate = new DateTime(new DateOnly(2002, 12, 18), new TimeOnly(0)),
                        CollegeProgram = "Information Technology",
                        YearInProgram = "Junior"
                    },
                    new() {
                        FullName = "Andrew Bagby",
                        BirthDate = new DateTime(new DateOnly(2004, 5, 10), new TimeOnly(0)),
                        CollegeProgram = "Information Technology",
                        YearInProgram = "Sophomore"
                    }
                    // Add more seed data as needed
                };

                var memberDetailsSet = new List<MemberDetails>
                {
                    new() {
                        TeamMember = teamMembers.Find(x => x.FullName == "Paul Sparks"),
                        FavoriteFood = "Pad Thai",
                        FavoriteColor = "Black",
                        Age = 19,
                        FavoriteTVShow = "Breaking Bad",
                        FavoriteDrink = "Water"
                    },
                    new() {
                        TeamMember = teamMembers.Find(x => x.FullName == "Drake Damron"),
                        FavoriteFood = "Pizza",
                        FavoriteColor = "Green",
                        Age = 20,
                        FavoriteTVShow = "The Office",
                        FavoriteDrink = "Dr. Pepper"
                    },
                    new() {
                        TeamMember = teamMembers.Find(x => x.FullName == "Andrew Bagby"),
                        FavoriteFood = "Orange Chicken",
                        FavoriteColor = "Blue",
                        Age = 19,
                        FavoriteTVShow = "Parks and Rec",
                        FavoriteDrink = "Sprite"
                    }
                };

                dbContext.TeamMembers.AddRange(teamMembers);
                dbContext.MemberDetailsSet.AddRange(memberDetailsSet);
            }

            if (!dbContext.Animals.Any()) {
                var animals = new List<Animal>
                {
                    new() {
                        AnimalName = "Lion"
                        // TODO: populate with the newly added properties from Animal.cs after they're added
                    }
                    // TODO: populate this list with 8 more animals
                };

                dbContext.Animals.AddRange(animals);
            }

            if (!dbContext.StoreItems.Any()) {
                var storeItems = new List<StoreItem>
                {
                    new() {
                        ItemName = "Bread",
                        Price = 2.99
                        // TODO: populate with the newly added properties from StoreItem.cs after they're added
                    }
                    // TODO: populate this list with 4 more store items
                };

                dbContext.StoreItems.AddRange(storeItems);
            }

            dbContext.SaveChanges();
        }

        private static void ClearData(AppDbContext dbContext)
        {
            // Reset identity to 1
            dbContext.Database.ExecuteSqlRaw("DBCC CHECKIDENT('dbo.TeamMembers', RESEED, 0)");
            dbContext.Database.ExecuteSqlRaw("DBCC CHECKIDENT('dbo.MemberDetailsSet', RESEED, 0)");
            dbContext.Database.ExecuteSqlRaw("DBCC CHECKIDENT('dbo.Animals', RESEED, 0)");
            dbContext.Database.ExecuteSqlRaw("DBCC CHECKIDENT('dbo.StoreItems', RESEED, 0)");

            // Delete all records
            dbContext.TeamMembers.RemoveRange(dbContext.TeamMembers);
            dbContext.MemberDetailsSet.RemoveRange(dbContext.MemberDetailsSet);
            dbContext.Animals.RemoveRange(dbContext.Animals);
            dbContext.StoreItems.RemoveRange(dbContext.StoreItems);

            dbContext.SaveChanges();
        }

    }

}
