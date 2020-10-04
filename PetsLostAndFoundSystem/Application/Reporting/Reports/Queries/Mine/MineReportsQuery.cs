namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Queries.Mine
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Contracts;
    using Common;
    using Reporters;
    using MediatR;

    public class MineReportsQuery : ReportsQuery, IRequest<MineReportsOutputModel>
    {
        public class MineReportsQueryHandler : ReportsQueryHandler, IRequestHandler<
           MineReportsQuery,
           MineReportsOutputModel>
        {
            private readonly IReporterQueryRepository reporterRepository;
            private readonly ICurrentUser currentUser;

            public MineReportsQueryHandler(
                IReportQueryRepository reportRepository,
                IReporterQueryRepository reporterRepository,
                ICurrentUser currentUser)
                : base(reportRepository)
            {
                this.currentUser = currentUser;
                this.reporterRepository = reporterRepository;
            }

            public async Task<MineReportsOutputModel> Handle(
                MineReportsQuery request,
                CancellationToken cancellationToken)
            {
                var ReporterId = await this.reporterRepository.GetReporterId(
                    this.currentUser.UserId,
                    cancellationToken);

                var mineReportListings = await base.GetReportListings<MineReportOutputModel>(
                    request,
                    onlyApproved: false,
                    ReporterId,
                    cancellationToken);

                var totalPages = await base.GetTotalPages(
                    request,
                    onlyApproved: false,
                    ReporterId,
                    cancellationToken);

                return new MineReportsOutputModel(mineReportListings, request.Page, totalPages);
            }
        }
    }
}
