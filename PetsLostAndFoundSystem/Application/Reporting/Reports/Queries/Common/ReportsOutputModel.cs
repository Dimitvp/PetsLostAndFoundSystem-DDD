namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Queries.Common
{
    using System.Collections.Generic;

    public abstract class ReportsOutputModel<TReportOutputModel>
    {
        internal ReportsOutputModel(
            IEnumerable<TReportOutputModel> reports,
            int page,
            int totalPages)
        {
            this.Reports = reports;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<TReportOutputModel> Reports { get; }

        public int Page { get; }

        public int TotalPages { get; }
    }
}
