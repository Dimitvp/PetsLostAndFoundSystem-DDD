namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Queries.Search
{
    using System.Collections.Generic;
    using Common;

    public class SearchReportsOutputModel : ReportsOutputModel<ReportOutputModel>
    {
        public SearchReportsOutputModel(
            IEnumerable<ReportOutputModel> reports,
            int page,
            int totalPages)
            : base(reports, page, totalPages)
        {
        }
    }
}
