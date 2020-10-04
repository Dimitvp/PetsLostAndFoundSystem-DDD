namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Contracts;
    using Common;
    using Reporters;
    using Domain.Common.Models;
    using Domain.Reporting.Factories.Reports;
    using Domain.Reporting.Models.Reports;
    using Domain.Reporting.Repositories;
    using MediatR;

    public class CreateReportCommand : ReportCommand<CreateReportCommand>, IRequest<CreateReportOutputModel>
    {
        public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, CreateReportOutputModel>
        {
            private readonly ICurrentUser currentUser;
            private readonly IReporterDomainRepository reporterRepository;
            private readonly IReportDomainRepository reportRepository;
            private readonly IReportFactory reportFactory;

            public CreateReportCommandHandler(
                ICurrentUser currentUser,
                IReporterDomainRepository reporterRepository,
                IReportDomainRepository reportRepository,
                IReportFactory reportFactory)
            {
                this.currentUser = currentUser;
                this.reporterRepository = reporterRepository;
                this.reportRepository = reportRepository;
                this.reportFactory = reportFactory;
            }

            public async Task<CreateReportOutputModel> Handle(
                CreateReportCommand request,
                CancellationToken cancellationToken)
            {
                var reporter = await this.reporterRepository.FindByUser(
                    this.currentUser.UserId,
                    cancellationToken);

                var pet = await this.reportRepository.GetPet(request.Id, cancellationToken);

                var factory = pet == null
                    ? this.reportFactory.WithPet(request.PetId)
                    : this.reportFactory.WithPet(pet);

                var report = factory
                    .WithStatus(Enumeration.FromValue<PetStatusType>(request.Status))
                    .WithRewardSum(request.RewardSum)
                    .WithImageUrl(request.ImgsLinksPosts)
                    .WithLostDate(request.LostDate)
                    .WithLocation(request.LocationAddress, request.Latitude, request.Longitude)
                    .Build();

                reporter.AddReport(report);

                await this.reportRepository.Save(report, cancellationToken);

                return new CreateReportOutputModel(report.Id);
            }
        }
    }
}
