namespace PetsLostAndFoundSystem.Infrastructure.Reporting.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Reporting.Reports;
    using Application.Reporting.Reports.Queries.Categories;
    using Application.Reporting.Reports.Queries.Common;
    using Application.Reporting.Reports.Queries.Details;
    using AutoMapper;
    using Common;
    using Common.Persistence;
    using Domain.Common;
    using Domain.Reporting.Models.Reports;
    using Domain.Reporting.Models.Reporters;
    using Microsoft.EntityFrameworkCore;

    internal class ReportRepository : DataRepository<IReportingDbContext, Report>, IReportQueryRepository
    {
        private readonly IMapper mapper;

        public ReportRepository(IReportingDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;
    }
}
