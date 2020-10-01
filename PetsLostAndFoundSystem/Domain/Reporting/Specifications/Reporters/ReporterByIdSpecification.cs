namespace PetsLostAndFoundSystem.Domain.Reporting.Specifications.Reporters
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Models.Reporters;


    public class ReporterByIdSpecification : Specification<Reporter>
    {
        private readonly int? id;

        public ReporterByIdSpecification(int? id)
            => this.id = id;

        protected override bool Include => this.id != null;

        public override Expression<Func<Reporter, bool>> ToExpression()
            => reporter => reporter.Id == this.id;
    }
}
