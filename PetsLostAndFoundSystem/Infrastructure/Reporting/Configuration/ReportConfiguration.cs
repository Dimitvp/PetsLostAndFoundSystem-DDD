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
            
        }
    }
}
