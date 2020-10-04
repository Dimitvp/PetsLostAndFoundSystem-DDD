namespace PetsLostAndFoundSystem.Infrastructure.Reporting.Configuration
{
    using Domain.Reporting.Models.Reports;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder
                .HasKey(c => c.Id);
        }
    }
}
