namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Commands.Create
{
    public class CreateReportOutputModel
    {
        public CreateReportOutputModel(int reportId)
            => this.ReportId = reportId;

        public int ReportId { get; set; }
    }
}
