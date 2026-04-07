using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Persistence.Configurations
{
    public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.IssuedBy)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.IssuedAt)
                .IsRequired();

            builder.Property(c => c.ExpiresAt);
        }
    }
}
