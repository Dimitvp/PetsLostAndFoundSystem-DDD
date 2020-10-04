namespace PetsLostAndFoundSystem.Infrastructure.Reporting.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Reporting.Reports;
    using Application.Reporting.Reports.Queries.Common;
    using Application.Reporting.Reports.Queries.Details;
    using AutoMapper;
    using Common;
    using Common.Persistence;
    using Domain.Common;
    using Domain.Reporting.Models.Reports;
    using Domain.Reporting.Models.Reporters;
    using Microsoft.EntityFrameworkCore;

    internal class ReportRepository : DataRepository<IReportingDbContext, Report>, IReportQueryRepository
    {
        private readonly IMapper mapper;

        public ReportRepository(IReportingDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<Report> Find(int id, CancellationToken cancellationToken = default)
            => await this
                .All()
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var report = await this.Data.Reports.FindAsync(id);

            if (report == null)
            {
                return false;
            }

            this.Data.Reports.Remove(report);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<IEnumerable<TOutputModel>> GetReportListings<TOutputModel>(
            Specification<Report> reportSpecification,
            Specification<Reporter> reporterSpecification,
            ReportsSortOrder reportsSortOrder,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default)
            => (await this.mapper
                .ProjectTo<TOutputModel>(this
                    .GetReportsQuery(reportSpecification, reporterSpecification)
                    .Sort(reportsSortOrder))
                .ToListAsync(cancellationToken))
                .Skip(skip)
                .Take(take); // EF Core bug forces me to execute paging on the client.

        public async Task<ReportDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<ReportDetailsOutputModel>(this
                    .AllAvailable()
                    .Where(c => c.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<int> Total(
            Specification<Report> ReportSpecification,
            Specification<Reporter> reporterSpecification,
            CancellationToken cancellationToken = default)
            => await this
                .GetReportsQuery(ReportSpecification, reporterSpecification)
                .CountAsync(cancellationToken);

        private IQueryable<Report> AllAvailable()
            => this
                .All()
                .Where(report => report.IsApproved);

        private IQueryable<Report> GetReportsQuery(
            Specification<Report> reportSpecification,
            Specification<Reporter> reporterSpecification)
            => this
                .Data
                .Reporters
                .Where(reporterSpecification)
                .SelectMany(d => d.Reports)
                .Where(reportSpecification);
    }
}
