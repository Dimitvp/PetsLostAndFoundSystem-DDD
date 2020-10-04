namespace PetsLostAndFoundSystem.Application.Statistics
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Contracts;
    using Domain.Statistics.Models;
    using Queries.Current;

    public interface IStatisticsRepository : IQueryRepository<Statistics>
    {
        Task<GetCurrentStatisticsOutputModel> GetCurrent(CancellationToken cancellationToken = default);

        Task<int> GetReportViews(int repoortId, CancellationToken cancellationToken = default);

        Task IncrementReports(CancellationToken cancellationToken = default);
    }
}
