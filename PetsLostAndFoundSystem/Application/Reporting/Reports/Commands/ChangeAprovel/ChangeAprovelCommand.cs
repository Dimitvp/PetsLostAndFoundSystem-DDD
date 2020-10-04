namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Commands.ChangeAprovel
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Common.Contracts;
    using Common;
    using Reporters;
    using MediatR;

    public class ChangeAprovelCommand : EntityCommand<int>, IRequest<Result>
    {
        private readonly ICurrentUser currentUser;
        private readonly IReportQueryRepository reportRepository;
        private readonly IReporterQueryRepository reporterRepository;

        public ChangeAprovelCommand(
            ICurrentUser currentUser,
            IReportQueryRepository reportRepository,
            IReporterQueryRepository reporterRepository)
        {
            this.currentUser = currentUser;
            this.reportRepository = reportRepository;
            this.reporterRepository = reporterRepository;
        }

        public async Task<Result> Handle(
            ChangeAprovelCommand request,
            CancellationToken cancellationToken)
        {
            var reporterHasReport = await this.currentUser.ReporterHasReport(
                this.reporterRepository,
                request.Id,
                cancellationToken);

            if (!reporterHasReport)
            {
                return reporterHasReport;
            }

            var report = await this.reportRepository
                .Find(request.Id, cancellationToken);

            report.ChangeAvailability();

            await this.reportRepository.Save(report, cancellationToken);

            return Result.Success;
        }
    }
}
