namespace PetsLostAndFoundSystem.Domain.Reporting.Specifications.Reports
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Models.Reports;

    public class ReportByPetSpecification : Specification<Report>
    {
        private readonly int? pet;

        public ReportByPetSpecification(int? pet)
            => this.pet = pet;

        protected override bool Include => this.pet != null;

        public override Expression<Func<Report, bool>> ToExpression()
            => report => report.Pet.Id == this.pet;
    }
}
