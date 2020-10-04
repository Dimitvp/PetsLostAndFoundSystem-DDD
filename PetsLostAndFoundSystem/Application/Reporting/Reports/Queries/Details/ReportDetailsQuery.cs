namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Queries.Details
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Reporters;
    using MediatR;

    public class ReportDetailsQuery : EntityCommand<int>, IRequest<ReportDetailsOutputModel>
    {
        public class ReportDetailsQueryHandler : IRequestHandler<ReportDetailsQuery, ReportDetailsOutputModel>
        {
            private readonly IReportQueryRepository reportRepository;
            private readonly IReporterQueryRepository reporterRepository;

            public ReportDetailsQueryHandler(
                IReportQueryRepository reportRepository,
                IReporterQueryRepository reporterRepository)
            {
                this.reportRepository = reportRepository;
                this.reporterRepository = reporterRepository;
            }

            public async Task<ReportDetailsOutputModel> Handle(
                ReportDetailsQuery request,
                CancellationToken cancellationToken)
            {
                var reportDetails = await this.reportRepository.GetDetails(
                    request.Id,
                    cancellationToken);

                reportDetails.Reporter = await this.reporterRepository.GetDetailsByReportId(
                    request.Id,
                    cancellationToken);

                return reportDetails;
            }
        }
    }
}
