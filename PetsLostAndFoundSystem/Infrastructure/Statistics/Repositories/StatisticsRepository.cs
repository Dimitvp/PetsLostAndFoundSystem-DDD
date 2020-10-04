namespace PetsLostAndFoundSystem.Infrastructure.Statistics.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Statistics;
    using Application.Statistics.Queries.Current;
    using AutoMapper;
    using Common.Persistence;
    using Domain.Statistics.Models;
    using Microsoft.EntityFrameworkCore;

    internal class StatisticsRepository : DataRepository<IStatisticsDbContext, Statistics>, IStatisticsRepository
    {
        private readonly IMapper mapper;

        public StatisticsRepository(IStatisticsDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<GetCurrentStatisticsOutputModel> GetCurrent(CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<GetCurrentStatisticsOutputModel>(this.All())
                .SingleOrDefaultAsync(cancellationToken);

        public async Task<int> GetReportViews(int reportId, CancellationToken cancellationToken = default)
            => await this.Data
                .ReportViews
                .CountAsync(cav => cav.ReportId == reportId, cancellationToken);

        public async Task IncrementReports(CancellationToken cancellationToken = default)
        {
            var statistics = await this.Data
                .Statistics
                .SingleOrDefaultAsync(cancellationToken);

            statistics.AddReport();

            await this.Save(statistics, cancellationToken);
        }
    }
}
