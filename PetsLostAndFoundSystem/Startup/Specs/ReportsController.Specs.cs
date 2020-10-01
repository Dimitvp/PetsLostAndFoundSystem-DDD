namespace PetsLostAndFoundSystem.Startup.Specs
{
    using System.Linq;
    using Application.Reporting.Reports.Queries.Search;
    using Domain.Reporting.Models.Reporters;
    using FluentAssertions;
    using MyTested.AspNetCore.Mvc;
    using Web.Features;
    using Xunit;

    public class ReportsControllerSpecs
    {
        [Fact]
        public void SearchShouldHaveCorrectAttributes()
           => MyController<ReportsController>
               .Calling(c => c.Search(With.Default<SearchReportsQuery>()))

               .ShouldHave()
               .ActionAttributes(attr => attr
                   .RestrictingForHttpMethod(HttpMethod.Get));

        [Theory]
        [InlineData(2)]
        public void SearchShouldReturnAllReportsWithoutAQuery(int totalReports)
            => MyPipeline
                .Configuration()
                .ShouldMap("/Reports")

                .To<ReportsController>(c => c.Search(With.Empty<SearchReportsQuery>()))
                .Which(instance => instance
                    .WithData(ReporterFakes.Data.GetReporter(totalReports: totalReports)))

                .ShouldReturn()
                .ActionResult<SearchReportsOutputModel>(result => result
                    .Passing(model => model
                        .Reports.Count().Should().Be(totalReports)));

        [Fact]
        public void SearchShouldReturnAprovedReportsWithoutAQuery()
            => MyPipeline
                .Configuration()
                .ShouldMap("/Reports")

                .To<ReportsController>(c => c.Search(With.Empty<SearchReportsQuery>()))
                .Which(instance => instance
                    .WithData(ReporterFakes.Data.GetReporter()))

                .ShouldReturn()
                .ActionResult<SearchReportsOutputModel>(result => result
                    .Passing(model => model
                        .Reports.Count().Should().Be(10)));
    }
}
