namespace PetsLostAndFoundSystem.Application.Reporting.Reporters.Queries.Common
{
    using Application.Common.Mapping;
    using AutoMapper;
    using Domain.Reporting.Models.Reporters;

    public class ReporterOutputModel : IMapFrom<Reporter>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string PhoneNumber { get; private set; } = default!;

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Reporter, ReporterOutputModel>()
                .ForMember(d => d.PhoneNumber, cfg => cfg
                    .MapFrom(d => d.PhoneNumber.Number));
    }
}
