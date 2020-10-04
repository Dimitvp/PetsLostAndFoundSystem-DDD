namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Queries.Common
{
    using System;
    using System.Linq.Expressions;
    using Application.Common;
    using Domain.Reporting.Models.Reports;

    public class ReportsSortOrder : SortOrder<Report>
    {
        public ReportsSortOrder(string? sortBy, string? order)
           : base(sortBy, order)
        {
        }

        public override Expression<Func<Report, object>> ToExpression()
            => this.SortBy switch
            {
                "LostDate" => report => report.LostDate,
                "petType" => report => report.Pet.PetType,
                _ => report => report.Id
            };
    }
}
