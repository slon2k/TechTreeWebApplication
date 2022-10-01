using Microsoft.AspNetCore.Identity;
using TechTreeWebApplication.Data;
using TechTreeWebApplication.Entities;
using TechTreeWebApplication.Options;

namespace TechTreeWebApplication.Extensions
{
    public static class WebAppExtensions
    {
        public static void InitializeDb(this WebApplication app, ConfigurationManager configuration)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                
                var context = services.GetRequiredService<ApplicationDbContext>();
                
                context.Database.EnsureCreated();
                
                var adminSettings = configuration.GetSection("AdminSettings").Get<AdminSettings>();
                
                var userManager = services.GetService<UserManager<ApplicationUser>>();
                
                if (userManager is null)
                {
                    throw new Exception("UserManager is null");
                }
                
                ApplicationDbInitializer.SeedUsers(userManager, adminSettings);
            }
        }
    }
}
