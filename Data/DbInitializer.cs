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
                        AnimalName = "Lion",
                        LifeSpan = 16,
                        Color = "Orange",
                        Location = "South Africa"
                    },
                    new() {
                        AnimalName = "Monkey",
                        LifeSpan = 20,
                        Color = "Brown",
                        Location = "Asis/Africa"
                    },
                    new() {
                        AnimalName = "Elephant",
                        LifeSpan = 70,
                        Color = "Gray/Brown",
                        Location = "Ais/Africa"
                    },
                    new() {
                        AnimalName = "Zebra",
                        LifeSpan = 20,
                        Color = "White/Black",
                        Location = "South Africa"
                    },
                    new() {
                        AnimalName = "Giraffe",
                        LifeSpan = 25,
                        Color = "Orange/Brown",
                        Location = "Africa"
                    },
                    new() {
                        AnimalName = "Black Bear",
                        LifeSpan = 30,
                        Color = "Black",
                        Location = "Alaska/Canada"
                    },
                    new() {
                        AnimalName = "Deer",
                        LifeSpan = 20,
                        Color = "Brown",
                        Location = "Many"
                    },
                    new() {
                        AnimalName = "Moose",
                        LifeSpan = 25,
                        Color = "Brown",
                        Location = "Alaska/Canada"
                    },
                    new() {
                        AnimalName = "Kangaroo",
                        LifeSpan = 25,
                        Color = "Brown",
                        Location = "Australia"
                    }
                };

                dbContext.Animals.AddRange(animals);
            }

            if (!dbContext.StoreItems.Any()) {
                var storeItems = new List<StoreItem>
                {
                    new() {
                        ItemName = "Bread",
                        Price = 2.99,
                        ItemBrand = "Wonder",
                        Quantity = 1
                    },
                    new() {
                        ItemName = "Hot Dog",
                        Price = 1.99,
                        ItemBrand = "Khans",
                        Quantity = 1
                    },
                    new() {
                        ItemName = "Chips",
                        Price = 3.99,
                        ItemBrand = "Lays",
                        Quantity = 1
                    },
                    new() {
                        ItemName = "Milk",
                        Price = 1.50,
                        ItemBrand = "Fairlife",
                        Quantity = 1
                    },
                    new() {
                        ItemName = "Chocolate",
                        Price = 2.99,
                        ItemBrand = "Hershey",
                        Quantity = 1
                    }
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
