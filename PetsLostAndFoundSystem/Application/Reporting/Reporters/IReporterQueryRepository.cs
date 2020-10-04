namespace PetsLostAndFoundSystem.Application.Reporting.Reporters
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Contracts;
    using Domain.Reporting.Models.Reporters;
    using Queries.Common;
    using Queries.Details;

    public interface IReporterQueryRepository : IQueryRepository<Reporter>
    {
        Task<ReporterDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<ReporterOutputModel> GetDetailsByReportId(int reportId, CancellationToken cancellationToken = default);

        Task Save(ReporterOutputModel reporter,CancellationToken cancellationToken = default);

        Task<ReporterOutputModel> FindByUser(string userId, CancellationToken cancellationToken = default);
    }
}
