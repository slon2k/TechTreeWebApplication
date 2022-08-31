using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TechTreeWebApplication.Entities;
using TechTreeWebApplication.Extensions;
using TechTreeWebApplication.Converters;

namespace TechTreeWebApplication.EntityConfigurations
{
    public class CategoryItemConfiguration : IEntityTypeConfiguration<CategoryItemEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryItemEntity> builder)
        {
            builder.ToTable("CategoryItem");
            
            builder.HasUniqueIdentifier<CategoryItemEntity, int>();
            
            builder.HasTitle();

            builder.HasDescription();

            builder.Property(e => e.DateReleased)
                .HasConversion<DateOnlyConverter>()
                .HasColumnType("date"); ;

            builder.HasOne(e => e.Category)
                .WithMany(e => e.CategoryItems)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.MediaType)
                .WithMany(e => e.CategoryItems)
                .HasForeignKey(e => e.MediaTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
