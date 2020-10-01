namespace PetsLostAndFoundSystem.Application.Reporting.Reporters.Commands.Edit
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Common.Contracts;
    using MediatR;

    public class EditReporterCommand : EntityCommand<int>, IRequest<Result>
    {
        public string Name { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public class EditReporterCommandHandler : IRequestHandler<EditReporterCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IReporterQueryRepository reporterRepository;

            public EditReporterCommandHandler(
                ICurrentUser currentUser,
                IReporterQueryRepository reporterRepository)
            {
                this.currentUser = currentUser;
                this.reporterRepository = reporterRepository;
            }

            public async Task<Result> Handle(
                EditReporterCommand request,
                CancellationToken cancellationToken)
            {
                var reporter = await this.reporterRepository.FindByUser(
                    this.currentUser.UserId,
                    cancellationToken);

                if (request.Id != reporter.Id)
                {
                    return "You cannot edit this reporter.";
                }

                reporter
                    .UpdateName(request.Name)
                    .UpdatePhoneNumber(request.PhoneNumber);

                await this.reporterRepository.Save(reporter, cancellationToken);

                return Result.Success;
            }
        }
    }
}
