namespace PetsLostAndFoundSystem.Application.Identity.Commands.CreateUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Reporting.Reporters;
    using Domain.Reporting.Factories.Reporters;
    using MediatR;

    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public string Name { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity identity;
            private readonly IReporterFactory reporterFactory;
            private readonly IReporterQueryRepository reporterRepository;

            public CreateUserCommandHandler(
                IIdentity identity,
                IReporterFactory reporterFactory,
                IReporterQueryRepository reporterRepository)
            {
                this.identity = identity;
                this.reporterFactory = reporterFactory;
                this.reporterRepository = reporterRepository;
            }

            public async Task<Result> Handle(
                CreateUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Register(request);

                if (!result.Succeeded)
                {
                    return result;
                }

                var user = result.Data;

                var reporter = this.reporterFactory
                    .WithName(request.Name)
                    .WithPhoneNumber(request.PhoneNumber)
                    .Build();

                user.BecomeReporter(reporter);

                await this.reporterRepository.Save(reporter, cancellationToken);

                return result;
            }
        }
    }
}
