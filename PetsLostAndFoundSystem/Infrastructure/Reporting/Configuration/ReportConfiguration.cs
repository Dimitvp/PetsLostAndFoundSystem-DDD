namespace PetsLostAndFoundSystem.Infrastructure.Reporting.Configuration
{
    using Domain.Reporting.Models.Reports;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static Domain.Reporting.Models.ModelConstants.Common;
    using static Domain.Reporting.Models.ModelConstants.Report;

    internal class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .HasOne(r => r.Pet)
                .WithOne()
                .HasForeignKey("PatId")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(r => r.RewardSum)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder
                .Property(r => r.ImagesLinksPost)
                .IsRequired()
                .HasMaxLength(MaxUrlLength);

            builder
                .Property(r => r.IsApproved)
                .IsRequired();

            builder
                .Property(r => r.Status)
                .IsRequired();

            builder
                .Property(r => r.Location)
                .IsRequired();
        }
    }
}
