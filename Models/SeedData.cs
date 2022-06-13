using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;



namespace IphonesStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            IphonesStoreDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IphonesStoreDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Iphones.Any())
            {
                context.Iphones.AddRange(
                new Iphone
                {
                    Title = "Iphone 12",
                    Description = "An Easy & Proven Way to Build Good Habits & Break Bad Ones",
                    Genre = "Self - Help",
                    Price = 11.98m
                },
                new Iphone
                {
                    Title = "Iphone 13",
                    Description = "You can go after the job you want...and get it! You can take the job you have...and improve it!",
                    Genre = "Self - Help",
                    Price = 17.46m
                },
                new Iphone
                {
                    Title = "Iphone 13 pro",
                    Description = "What the Rich Teach Their Kids About Money That the Poor and Middle Class Do Not!",
                    Genre = "Personal Finance",
                    Price = 13.41m
                },
                new Iphone
                {
                    Title = "Iphone 13 promax",
                    Description = "Doing well with money isn’t  necessarily about what you know.It’s about how you behave.And behavior is hard to teach,even to really smart people.",
                    Genre = "Money Management",
                    Price = 18.69m
                },
                new Iphone
                {
                    Title = "Iphone 12 promax",
                    Description = "Amoral, cunning, ruthless, and instructive, this piercing work distills 3,000 years of the history of power into 48 well - explicated laws.",
                    Genre = "Political Science",
                    Price = 31.26m
                }
                );
                context.SaveChanges();
            }
        }
    }
}