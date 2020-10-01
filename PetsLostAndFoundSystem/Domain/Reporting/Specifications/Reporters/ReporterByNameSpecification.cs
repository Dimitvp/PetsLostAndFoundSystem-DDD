namespace PetsLostAndFoundSystem.Domain.Reporting.Specifications.Reporters
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Models.Reporters;

    public class ReporterByNameSpecification : Specification<Reporter>
    {
        private readonly string? name;

        public ReporterByNameSpecification(string? name)
            => this.name = name;

        protected override bool Include => this.name != null;

        public override Expression<Func<Reporter, bool>> ToExpression()
            => reporter => reporter.Name.ToLower().Contains(this.name!.ToLower());
    }
}
