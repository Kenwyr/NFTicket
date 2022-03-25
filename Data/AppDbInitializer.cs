using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NFT_API.Data.Static;
using NFT_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFT_API.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Location
                if (!context.Locations.Any())
                {
                    context.Locations.AddRange(new List<Location>()
                    {
                        new Location()
                        {
                            Name = "Forum",
                            Logo = "https://i.ibb.co/18LY5YG/forum.jpg",
                            Description = "This is the description of the first Location"
                        },
                        new Location()
                        {
                            Name = "kh hallen",
                            Logo = "https://i.ibb.co/X5q6mwV/kb-hallen-og-image-1648x863.jpg",
                            Description = "This is the description of the first Location"
                        },
                        new Location()
                        {
                            Name = "Royal Arena",
                            Logo = "https://i.ibb.co/qWSmM0P/Royal-Arena-Copenhagen.jpg",
                            Description = "This is the description of the first Location"
                        },
                        new Location()
                        {
                            Name = "Location 4",
                            Logo = "https://i.ibb.co/qWSmM0P/Royal-Arena-Copenhagen.jpg",
                            Description = "This is the description of the first Location"
                        },
                        new Location()
                        {
                            Name = "Location 5",
                            Logo = "https://i.ibb.co/qWSmM0P/Royal-Arena-Copenhagen.jpg",
                            Description = "This is the description of the first Location"
                        },
                    });
                    context.SaveChanges();
                }
                //Actors
                if (!context.Artists.Any())
                {
                    context.Artists.AddRange(new List<Artist>()
                    {
                        new Artist()
                        {
                            FullName = "five finger death punch",
                            Bio = "Five Finger Death Punch er et amerikansk heavy metal band fra Las Vegas, Nevada. Bandet blev dannet 2005 og tog sit navn fra Kung fu filmen The Five Fingers of Death fra 1972",
                            ProfilePictureURL = "https://i.ibb.co/cCp6VYs/ab6761610000e5eb5e0ecf916bbfcdfb1368793d.jpg"

                        },
                        new Artist()
                        {
                            FullName = "Artist 2",
                            Bio = "This is the Bio of the second artist",
                            ProfilePictureURL = "https://i.ibb.co/cCp6VYs/ab6761610000e5eb5e0ecf916bbfcdfb1368793d.jpg"
                        },
                        new Artist()
                        {
                            FullName = "Artist 3",
                            Bio = "This is the Bio of the second artist",
                            ProfilePictureURL = "https://i.ibb.co/cCp6VYs/ab6761610000e5eb5e0ecf916bbfcdfb1368793d.jpg"
                        },
                        new Artist()
                        {
                            FullName = "Artist 4",
                            Bio = "This is the Bio of the second artist",
                            ProfilePictureURL = "https://i.ibb.co/cCp6VYs/ab6761610000e5eb5e0ecf916bbfcdfb1368793d.jpg"
                        },
                        new Artist()
                        {
                            FullName = "Artist 5",
                            Bio = "This is the Bio of the second artist",
                            ProfilePictureURL = "https://i.ibb.co/cCp6VYs/ab6761610000e5eb5e0ecf916bbfcdfb1368793d.jpg"
                        }
                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.Publishers.Any())
                {
                    context.Publishers.AddRange(new List<Publisher>()
                    {
                        new Publisher()
                        {
                            FullName = "TicketMaster",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "https://i.ibb.co/1bZ03H9/B2-B-Site-Preview.jpg"

                        },
                        new Publisher()
                        {
                            FullName = "Producer 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "https://i.ibb.co/1bZ03H9/B2-B-Site-Preview.jpg"
                        },
                        new Publisher()
                        {
                            FullName = "Producer 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "https://i.ibb.co/1bZ03H9/B2-B-Site-Preview.jpg"
                        },
                        new Publisher()
                        {
                            FullName = "Producer 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "https://i.ibb.co/1bZ03H9/B2-B-Site-Preview.jpg"
                        },
                        new Publisher()
                        {
                            FullName = "Producer 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "https://i.ibb.co/1bZ03H9/B2-B-Site-Preview.jpg"
                        }
                    });
                    context.SaveChanges();
                }
                //Events
                if (!context.Events.Any())
                {
                    context.Events.AddRange(new List<Event>()
                    {
                        new Event()
                        {
                            Name = "COPENHELL 2022",
                            Description = "COPENHELL 2022 finder sted den 15. til 18. juni 2022 – sæt et stort, sort kryds i kalenderen ved disse datoer! Alle COPENHELL 2021-festivalbilletter vil også gælde til COPENHELL 2022",
                            Price = 39.50,
                            ImageURL = "https://i.ibb.co/C8rwDSr/unknown.png",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            LocationId = 3,
                            PublisherId = 3,
                            EventCategory = EventCategory.Festival
                        },
                        new Event()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImageURL = "https://i.ibb.co/C8rwDSr/unknown.png",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            LocationId = 1,
                            PublisherId = 1,
                            EventCategory = EventCategory.Action
                        },
                        new Event()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            ImageURL = "https://i.ibb.co/C8rwDSr/unknown.png",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            LocationId = 4,
                            PublisherId = 4,
                            EventCategory = EventCategory.Rock
                        },
                        new Event()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImageURL = "https://i.ibb.co/C8rwDSr/unknown.png",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            LocationId = 1,
                            PublisherId = 2,
                            EventCategory = EventCategory.Familie
                        },
                        new Event()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            ImageURL = "https://i.ibb.co/C8rwDSr/unknown.png",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            LocationId = 1,
                            PublisherId = 3,
                            EventCategory = EventCategory.Sport
                        },
                        new Event()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            ImageURL = "https://i.ibb.co/C8rwDSr/unknown.png",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            LocationId = 1,
                            PublisherId = 5,
                            EventCategory = EventCategory.Sport
                        }
                    });
                    context.SaveChanges();
                }
                //Artist & Movies
                if (!context.Artists_Events.Any())
                {
                    context.Artists_Events.AddRange(new List<Artist_Event>()
                    {
                        new Artist_Event()
                        {
                            ArtistId = 1,
                            EventId = 1
                        },
                        new Artist_Event()
                        {
                            ArtistId = 3,
                            EventId = 1
                        },

                         new Artist_Event()
                        {
                            ArtistId = 1,
                            EventId = 2
                        },
                         new Artist_Event()
                        {
                            ArtistId = 4,
                            EventId = 2
                        },

                        new Artist_Event()
                        {
                            ArtistId = 1,
                            EventId = 3
                        },
                        new Artist_Event()
                        {
                            ArtistId = 2,
                            EventId = 3
                        },
                        new Artist_Event()
                        {
                            ArtistId = 5,
                            EventId = 3
                        },


                        new Artist_Event()
                        {
                            ArtistId = 2,
                            EventId = 4
                        },
                        new Artist_Event()
                        {
                            ArtistId = 3,
                            EventId = 4
                        },
                        new Artist_Event()
                        {
                            ArtistId = 4,
                            EventId = 4
                        },


                        new Artist_Event()
                        {
                            ArtistId = 2,
                            EventId = 5
                        },
                        new Artist_Event()
                        {
                            ArtistId = 3,
                            EventId = 5
                        },
                        new Artist_Event()
                        {
                            ArtistId = 4,
                            EventId = 5
                        },
                        new Artist_Event()
                        {
                            ArtistId = 5,
                            EventId = 5
                        },


                        new Artist_Event()
                        {
                            ArtistId = 3,
                            EventId = 6
                        },
                        new Artist_Event()
                        {
                            ArtistId = 4,
                            EventId = 6
                        },
                        new Artist_Event()
                        {
                            ArtistId = 5,
                            EventId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
