namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Queries.Common
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Common;
    using Domain.Reporting.Models.Reports;
    using Domain.Reporting.Models.Reporters;
    using Domain.Reporting.Specifications.Reports;
    using Domain.Reporting.Specifications.Reporters;

    public class ReportsQuery
    {
        private const int ReportsPerPage = 10;

        public int? Pet { get; set; }

        public string? Reporter { get; set; }

        public string? SortBy { get; set; }

        public string? Order { get; set; }

        public int Page { get; set; } = 1;

        public abstract class ReportsQueryHandler
        {
            private readonly IReportQueryRepository reportRepository;

            protected ReportsQueryHandler(IReportQueryRepository reportRepository)
                => this.reportRepository = reportRepository;

            protected async Task<IEnumerable<TOutputModel>> GetReportListings<TOutputModel>(
                ReportsQuery request,
                bool onlyApproved = true,
                int? reporterId = default,
                CancellationToken cancellationToken = default)
            {
                var reportSpecification = this.GetReportSpecification(request, onlyApproved);

                var reporterSpecification = this.GetReporterSpecification(request, reporterId);

                var searchOrder = new ReportsSortOrder(request.SortBy, request.Order);

                var skip = (request.Page - 1) * ReportsPerPage;

                return await this.reportRepository.GetReportListings<TOutputModel>(
                    reportSpecification,
                    reporterSpecification,
                    searchOrder,
                    skip,
                    take: ReportsPerPage,
                    cancellationToken);
            }

            protected async Task<int> GetTotalPages(
                ReportsQuery request,
                bool onlyApproved = true,
                int? reporterId = default,
                CancellationToken cancellationToken = default)
            {
                var reportSpecification = this.GetReportSpecification(request, onlyApproved);

                var reporterSpecification = this.GetReporterSpecification(request, reporterId);

                var totalReports = await this.reportRepository.Total(
                    reportSpecification,
                    reporterSpecification,
                    cancellationToken);

                return (int)Math.Ceiling((double)totalReports / ReportsPerPage);
            }

            private Specification<Report> GetReportSpecification(ReportsQuery request, bool onlyApproved)
                => new ReportByPetSpecification(request.Pet)
                    .And(new ReportOnlyApprovedSpecification(onlyApproved));

            private Specification<Reporter> GetReporterSpecification(ReportsQuery request, int? reporterId)
                => new ReporterByIdSpecification(reporterId)
                    .And(new ReporterByNameSpecification(request.Reporter));
        }
    }
}
