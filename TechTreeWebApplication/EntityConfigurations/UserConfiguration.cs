using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechTreeWebApplication.Entities;

namespace TechTreeWebApplication.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(e => e.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Address1)
                .HasColumnName("Address1")
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(e => e.Address2)
                .HasColumnName("Address2")
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(e => e.PostCode)
                .HasColumnName("PostCode")
                .HasMaxLength(20)
                .IsRequired(false);
        }
    }
}
