using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechTreeWebApplication.Entities;

namespace TechTreeWebApplication.EntityConfigurations
{
    public class UserCategoryConfiguration : IEntityTypeConfiguration<UserCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<UserCategoryEntity> builder)
        {
            builder.HasKey(e => new { e.UserId, e.CategoryId });

            builder.HasOne(e => e.Category)
                .WithMany(e => e.UserCategories)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(e => e.User)
                .WithMany(e => e.UserCategories)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
