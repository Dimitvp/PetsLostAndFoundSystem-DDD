namespace PetsLostAndFoundSystem.Domain
{
    using Reporting.Factories.Reports;
    using Reporting.Factories.Reporters;
    using FluentAssertions;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class DomainConfigurationSpecs
    {
        [Fact]
        public void AddDomainShouldRegisterFactories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act
            var services = serviceCollection
                .AddDomain()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IReporterFactory>()
                .Should()
                .NotBeNull();

            services
                .GetService<IReportFactory>()
                .Should()
                .NotBeNull();
        }
    }
}
