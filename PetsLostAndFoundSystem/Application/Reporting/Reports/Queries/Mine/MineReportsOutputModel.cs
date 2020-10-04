namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Queries.Mine
{
    using System.Collections.Generic;
    using Common;

    public class MineReportsOutputModel : ReportsOutputModel<MineReportOutputModel>
    {
        public MineReportsOutputModel(
            IEnumerable<MineReportOutputModel> reports,
            int page,
            int totalPages)
            : base(reports, page, totalPages)
        {
        }
    }
}
