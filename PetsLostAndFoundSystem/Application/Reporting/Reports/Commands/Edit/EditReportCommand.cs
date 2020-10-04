namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Commands.Edit
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Common.Contracts;
    using Common;
    using Reporters;
    using Domain.Common.Models;
    using Domain.Reporting.Models.Reports;
    using Domain.Reporting.Repositories;
    using MediatR;

    public class EditReportCommand : ReportCommand<EditReportCommand>, IRequest<Result>
    {
        public class EditReportCommandHandler : IRequestHandler<EditReportCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IReportDomainRepository reportRepository;
            private readonly IReporterDomainRepository reporterRepository;

            public EditReportCommandHandler(
                ICurrentUser currentUser,
                IReportDomainRepository reportRepository,
                IReporterDomainRepository reporterRepository)
            {
                this.currentUser = currentUser;
                this.reportRepository = reportRepository;
                this.reporterRepository = reporterRepository;
            }

            public async Task<Result> Handle(
                EditReportCommand request,
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

                var pet = await this.reportRepository
                    .GetPet(request.PetId, cancellationToken);

                report
                    .UpdateStatus(Enumeration.FromValue<PetStatusType>(request.Status))
                    .UpdateRewardSum(request.RewardSum)
                    .UpdateLocation(request.LocationAddress, request.Latitude, request.Longitude)
                    .UpdatePet(pet)
                    .UpdateImageUrl(request.ImgsLinksPosts);

                await this.reportRepository.Save(report, cancellationToken);

                return Result.Success;
            }
        }
}
