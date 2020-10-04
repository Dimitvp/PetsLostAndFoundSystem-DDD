namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Queries.Common
{
    using Application.Common.Mapping;
    using AutoMapper;
    using Domain.Reporting.Models.Reports;

    public class ReportOutputModel : IMapFrom<Report>
    {
        public int Id { get; private set; }

        public int Pet { get; set; }

        public string ImagesLinksPost { get; private set; } = default!;

        public decimal RewardSum { get; private set; }

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Report, ReportOutputModel>()
                .ForMember(r => r.Pet, cfg => cfg
                    .MapFrom(r => r.Pet.Id));
    }
}
