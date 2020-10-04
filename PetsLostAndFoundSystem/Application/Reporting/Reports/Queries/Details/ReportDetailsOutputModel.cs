namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Queries.Details
{
    using AutoMapper;
    using Common;
    using Reporters.Queries.Common;
    using Domain.Common.Models;
    using Domain.Reporting.Models.Reports;

    public class ReportDetailsOutputModel : ReportOutputModel
    {
        public ReporterOutputModel Reporter { get; set; } = default!;
    }
}
