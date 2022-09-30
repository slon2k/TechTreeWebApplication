using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechTreeWebApplication.Enums;

namespace TechTreeWebApplication.EntityConfigurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        private readonly string AdminRoleName = Roles.Admin.ToString();
        private readonly string UserRoleName = Roles.User.ToString();

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new List<IdentityRole>
            {
                new IdentityRole{ Name=AdminRoleName, NormalizedName=AdminRoleName.ToUpper()},
                new IdentityRole{ Name=UserRoleName, NormalizedName=UserRoleName.ToUpper()}
            });
        }
    }
}
