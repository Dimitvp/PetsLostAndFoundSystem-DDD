namespace PetsLostAndFoundSystem.Infrastructure.Reporting.Configuration
{
    using Domain.Reporting.Models.Reporters;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static Domain.Reporting.Models.ModelConstants.Common;

    public class ReporterConfiguration : IEntityTypeConfiguration<Reporter>
    {
        public void Configure(EntityTypeBuilder<Reporter> builder)
        {
            builder
                .HasKey(r => r.Id);

            builder
               .Property(r => r.Name)
               .IsRequired()
               .HasMaxLength(MaxNameLength);

            builder
                .OwnsOne(
                    r => r.PhoneNumber,
                    p =>
                    {
                        p.WithOwner();

                        p.Property(pn => pn.Number);
                    });

            builder
                .HasMany(r => r.Reports)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("reports");
        }
    }
}
