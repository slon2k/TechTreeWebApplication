using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TechTreeWebApplication.Entities;
using TechTreeWebApplication.Extensions;

namespace TechTreeWebApplication.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryItemEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryItemEntity> builder)
        {
            builder.ToTable("Category");
            
            builder.HasUniqueIdentifier<CategoryItemEntity, int>();
            
            builder.HasTitle();
            
            builder.HasDescription();
        }
    }
}
