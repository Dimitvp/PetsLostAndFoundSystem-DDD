namespace PetsLostAndFoundSystem.Domain.Reporting.Specifications.Reports
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Models.Reports;

    public class ReportOnlyApprovedSpecification : Specification<Report>
    {
        private readonly bool onlyApproved;

        public ReportOnlyApprovedSpecification(bool onlyApproved)
           => this.onlyApproved = onlyApproved;

        public override Expression<Func<Report, bool>> ToExpression()
        {
            if (this.onlyApproved)
            {
                return report => report.IsApproved;
            }

            return report => true;
        }
    }
}
