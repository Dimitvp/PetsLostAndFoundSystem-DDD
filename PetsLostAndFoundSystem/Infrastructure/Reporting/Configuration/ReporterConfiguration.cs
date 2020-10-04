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
        
        }
    }
}
