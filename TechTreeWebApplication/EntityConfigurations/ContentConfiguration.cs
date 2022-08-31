using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechTreeWebApplication.Entities;
using TechTreeWebApplication.Extensions;

namespace TechTreeWebApplication.EntityConfigurations
{
    public class ContentConfiguration : IEntityTypeConfiguration<ContentEntity>
    {
        public void Configure(EntityTypeBuilder<ContentEntity> builder)
        {
            builder.ToTable("Content");

            builder.HasUniqueIdentifier<ContentEntity, int>();

            builder.HasTitle();

            builder.Property(e => e.HTMLContent)
                .HasColumnName("Html")
                .HasMaxLength(4000)
                .IsRequired(false);

            builder.Property(e => e.VideoLink)
                .HasColumnName("VideoLink")
                .HasMaxLength(255)
                .IsRequired(false);
        }
    }
}
