namespace PetsLostAndFoundSystem.Infrastructure.Reporting.Configuration
{
    using Domain.Reporting.Models.Reports;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static Domain.Reporting.Models.ModelConstants.Common;
    using static Domain.Reporting.Models.ModelConstants.Pet;

    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.PetType)
                .IsRequired();

            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(p => p.Age);

            builder
                .Property(p => p.RFID)
                .IsRequired();

            builder
                .Property(p => p.PetDescription)
                .IsRequired()
                .HasMaxLength(MaxDescriptionLength);
        }
    }
}
