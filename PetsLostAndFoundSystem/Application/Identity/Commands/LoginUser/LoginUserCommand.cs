namespace PetsLostAndFoundSystem.Application.Identity.Commands.LoginUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Reporting.Reporters;
    using MediatR;

    public class LoginUserCommand : UserInputModel, IRequest<Result<LoginOutputModel>>
    {
        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<LoginOutputModel>>
        {
            private readonly IIdentity identity;
            private readonly IReporterQueryRepository reporterRepository;

            public LoginUserCommandHandler(
                IIdentity identity,
                IReporterQueryRepository reporterRepository)
            {
                this.identity = identity;
                this.reporterRepository = reporterRepository;
            }

            public async Task<Result<LoginOutputModel>> Handle(
                LoginUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Login(request);

                if (!result.Succeeded)
                {
                    return result.Errors;
                }

                var user = result.Data;

                var reporterId = await this.reporterRepository.GetReporterId(user.UserId, cancellationToken);

                return new LoginOutputModel(user.Token, reporterId);
            }
        }
    }
}
