namespace PetsLostAndFoundSystem.Application.Statistics.Queries.Current
{
    using AutoMapper;
    using Common.Mapping;
    using Domain.Statistics.Models;

    public class GetCurrentStatisticsOutputModel : IMapFrom<Statistics>
    {
        public int TotalReports { get; private set; }

        public int TotalReportViews { get; private set; }

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<Statistics, GetCurrentStatisticsOutputModel>()
                .ForMember(cs => cs.TotalReports, cfg => cfg
                    .MapFrom(s => s.ReportViews.Count));
    }
}