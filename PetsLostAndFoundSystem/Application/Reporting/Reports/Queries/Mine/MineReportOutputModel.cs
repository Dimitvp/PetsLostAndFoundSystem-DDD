namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Queries.Mine
{
    using AutoMapper;
    using Common;
    using Domain.Reporting.Models.Reports;

    public class MineReportOutputModel : ReportOutputModel
    {
        public bool IsApproved { get; private set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Report, MineReportOutputModel>()
                .IncludeBase<Report, ReportOutputModel>();
    }
}
