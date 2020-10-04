namespace PetsLostAndFoundSystem.Application.Reporting.Reports
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Contracts;
    using Domain.Common;
    using Domain.Reporting.Models.Reports;
    using Domain.Reporting.Models.Reporters;
    using Queries.Common;
    using Queries.Details;

    public interface IReportQueryRepository : IQueryRepository<Report>
    {
        Task<IEnumerable<TOutputModel>> GetReportListings<TOutputModel>(
            Specification<Report> reportSpecification,
            Specification<Reporter> reporterSpecification,
            ReportsSortOrder reportsSortOrder,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);

        Task<ReportDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<int> Total(
            Specification<Report> reportSpecification,
            Specification<Reporter> reporterSpecification,
            CancellationToken cancellationToken = default);
    }
}
