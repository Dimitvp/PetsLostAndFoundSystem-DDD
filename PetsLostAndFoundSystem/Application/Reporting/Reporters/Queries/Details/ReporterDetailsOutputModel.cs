namespace PetsLostAndFoundSystem.Application.Reporting.Reporters.Queries.Details
{
    using AutoMapper;
    using Common;
    using Domain.Reporting.Models.Reporters;
    public class ReporterDetailsOutputModel : ReporterOutputModel
    {
        public int TotalReports { get; private set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Reporter, ReporterDetailsOutputModel>()
                .IncludeBase<Reporter, ReporterOutputModel>()
                .ForMember(d => d.TotalReports, cfg => cfg
                    .MapFrom(d => d.Reports.Count));
    }
}
