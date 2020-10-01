namespace PetsLostAndFoundSystem.Startup.Specs
{
    using Application.Reporting.Reporters.Queries.Details;
    using MyTested.AspNetCore.Mvc;
    using Web;
    using Web.Features;
    using Xunit;

    public class ReportersControllerSpecs
    {
        [Fact]
        public void DetailsShouldHaveCorrectAttributes()
            => MyController<ReportersController>
                .Calling(c => c.Details(With.Default<ReporterDetailsQuery>()))

                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Get)
                    .SpecifyingRoute(ApiController.Id));
    }
}
