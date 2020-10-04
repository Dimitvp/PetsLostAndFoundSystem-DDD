namespace PetsLostAndFoundSystem.Infrastructure.Reporting.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Reporting.Reporters;
    using Application.Reporting.Reporters.Queries.Common;
    using Application.Reporting.Reporters.Queries.Details;
    using AutoMapper;
    using Common.Persistence;
    using Domain.Reporting.Exceptions;
    using Domain.Reporting.Models.Reporters;
    using Identity;
    using Microsoft.EntityFrameworkCore;

    internal class ReporterRepository : DataRepository<IReportingDbContext, Reporter>, IReporterQueryRepository
    {
        private readonly IMapper mapper;

        public ReporterRepository(IReportingDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<bool> HasReport(int reporterId, int reportId, CancellationToken cancellationToken = default)
            => await this
                .All()
                .Where(r => r.Id == reporterId)
                .AnyAsync(r => r.Reports
                    .Any(c => c.Id == reportId), cancellationToken);

        public async Task<ReporterDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<ReporterDetailsOutputModel>(this
                    .All()
                    .Where(r => r.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<ReporterOutputModel> GetDetailsByReportId(int reportId, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<ReporterOutputModel>(this
                    .All()
                    .Where(r => r.Reports.Any(c => c.Id == reportId)))
                .SingleOrDefaultAsync(cancellationToken);

        public Task<int> GetReporterId(
            string userId,
            CancellationToken cancellationToken = default)
            => this.FindByUser(userId, user => user.Reporter!.Id, cancellationToken);

        public Task<Reporter> FindByUser(
            string userId,
            CancellationToken cancellationToken = default)
            => this.FindByUser(userId, user => user.Reporter!, cancellationToken);

        private async Task<T> FindByUser<T>(
            string userId,
            Expression<Func<User, T>> selector,
            CancellationToken cancellationToken = default)
        {
            var reporterData = await this
                .Data
                .Users
                .Where(u => u.Id == userId)
                .Select(selector)
                .FirstOrDefaultAsync(cancellationToken);

            if (reporterData == null)
            {
                throw new InvalidReporterException("This user is not a dealer.");
            }

            return reporterData;
        }
    }
}
