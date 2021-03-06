﻿namespace PetsLostAndFoundSystem.Domain.Reporting.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models.Reporters;

    public interface IReporterDomainRepository
    {
        Task<Reporter> FindByUser(string userId, CancellationToken cancellationToken = default);

        Task<int> GetReporterId(string userId, CancellationToken cancellationToken = default);

        Task<bool> HasReport(int reporterId, int reportId, CancellationToken cancellationToken = default);

        Task Save(Reporter report, CancellationToken cancellationToken = default);
    }
}
