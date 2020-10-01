namespace PetsLostAndFoundSystem.Application.Reporting.Reporters.Queries.Details
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class ReporterDetailsQuery : IRequest<ReporterDetailsOutputModel>
    {
        public int Id { get; set; }

        public class ReporterDetailsQueryHandler : IRequestHandler<ReporterDetailsQuery, ReporterDetailsOutputModel>
        {
            private readonly IReporterQueryRepository reporterRepository;

            public ReporterDetailsQueryHandler(IReporterQueryRepository reporterRepository)
                => this.reporterRepository = reporterRepository;

            public async Task<ReporterDetailsOutputModel> Handle(
                ReporterDetailsQuery request,
                CancellationToken cancellationToken)
                => await this.reporterRepository.GetDetails(request.Id, cancellationToken);
        }
    }
}
