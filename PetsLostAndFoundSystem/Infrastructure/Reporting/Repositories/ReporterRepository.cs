namespace PetsLostAndFoundSystem.Infrastructure.Reporting.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Reporting.Reporters;
    using Application.Reporting.Reporters.Queries.Common;
    using Application.Reporting.Reporters.Queries.Details;
    using AutoMapper;
    using Common.Persistence;
    using Domain.Reporting.Exceptions;
    using Domain.Reporting.Models.Reporters;
    using Identity;
    using Microsoft.EntityFrameworkCore;

    internal class ReporterRepository : DataRepository<IReportingDbContext, Reporter>, IReporterQueryRepository
    {
        private readonly IMapper mapper;

        public ReporterRepository(IReportingDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;
    }
}
