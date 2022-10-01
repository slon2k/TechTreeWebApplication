using Microsoft.AspNetCore.Identity;
using TechTreeWebApplication.Entities;
using TechTreeWebApplication.Enums;
using TechTreeWebApplication.Options;

namespace TechTreeWebApplication.Data
{
    public static class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<ApplicationUser> userManager, AdminSettings settings)
        {            
            if (userManager.FindByNameAsync(settings.UserName).Result is null)
            {
                var user = new ApplicationUser
                {
                    UserName = settings.UserName,
                    Email = settings.Email,
                    FirstName = settings.FirstName,
                    LastName = settings.LastName,
                    EmailConfirmed = true
                };

                IdentityResult result = userManager.CreateAsync(user, settings.Password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, Roles.Admin.ToString()).Wait();
                }
            }
        }
    }
}
