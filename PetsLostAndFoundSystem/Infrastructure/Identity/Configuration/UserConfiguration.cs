namespace PetsLostAndFoundSystem.Infrastructure.Identity.Configuration
{
    using Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasOne(u => u.)
                .WithOne()
                .HasForeignKey<User>()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
