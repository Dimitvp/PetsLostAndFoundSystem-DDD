namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Queries.Search
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using MediatR;

    public class SearchReportsQuery : ReportsQuery, IRequest<SearchReportsOutputModel>
    {
        public class SearchReportsQueryHandler : ReportsQueryHandler, IRequestHandler<
            SearchReportsQuery,
            SearchReportsOutputModel>
        {
            public SearchReportsQueryHandler(IReportQueryRepository reportRepository)
                : base(reportRepository)
            {
            }

            public async Task<SearchReportsOutputModel> Handle(
                SearchReportsQuery request,
                CancellationToken cancellationToken)
            {
                var reportListings = await base.GetReportListings<ReportOutputModel>(
                    request,
                    cancellationToken: cancellationToken);

                var totalPages = await base.GetTotalPages(
                    request,
                    cancellationToken: cancellationToken);

                return new SearchReportsOutputModel(reportListings, request.Page, totalPages);
            }
        }
    }
}
