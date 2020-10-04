namespace PetsLostAndFoundSystem.Infrastructure.Reporting
{
    using Common.Persistence;
    using Domain.Reporting.Models.Reports;
    using Domain.Reporting.Models.Reporters;
    using Identity;
    using Microsoft.EntityFrameworkCore;

    public interface IReportingDbContext : IDbContext
    {
        DbSet<Reporter> Reporters { get; }

        DbSet<Report> Reports { get; }

        DbSet<User> Users { get; } // TODO: Temporary workaround
    }
}
