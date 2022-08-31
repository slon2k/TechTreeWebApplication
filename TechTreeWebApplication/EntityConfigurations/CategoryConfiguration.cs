using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TechTreeWebApplication.Entities;
using TechTreeWebApplication.Extensions;

namespace TechTreeWebApplication.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("Category");
            
            builder.HasUniqueIdentifier<CategoryEntity, int>();
            
            builder.HasTitle();
            
            builder.Property(e => e.Description)
                .HasColumnName("Description")
                .HasMaxLength(4000);
            
            builder.Property(e => e.Thumbnail)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
