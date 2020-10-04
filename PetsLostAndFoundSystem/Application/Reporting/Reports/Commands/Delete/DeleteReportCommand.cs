namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Common.Contracts;
    using Common;
    using Domain.Reporting.Repositories;
    using MediatR;


    public class DeleteReportCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteReportCommandHandler : IRequestHandler<DeleteReportCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IReportQueryRepository reportRepository;
            private readonly IReporterDomainRepository reporterRepository;

            public DeleteReportCommandHandler(
                ICurrentUser currentUser,
                IReportQueryRepository reportRepository,
                IReporterDomainRepository reporterRepository)
            {
                this.currentUser = currentUser;
                this.reportRepository = reportRepository;
                this.reporterRepository = reporterRepository;
            }

            public async Task<Result> Handle(
                DeleteReportCommand request,
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

                return await this.reportRepository.Delete(
                    request.Id,
                    cancellationToken);
            }
        }
    }
}
