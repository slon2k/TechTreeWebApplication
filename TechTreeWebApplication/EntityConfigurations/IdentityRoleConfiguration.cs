using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechTreeWebApplication.EntityConfigurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        private const string AdminName = "Admin";
        private const string UserName = "User";

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new List<IdentityRole>
            {
                new IdentityRole{ Name=AdminName, NormalizedName=AdminName.ToUpper()},
                new IdentityRole{ Name=UserName, NormalizedName=UserName.ToUpper()}
            });
        }
    }
}
