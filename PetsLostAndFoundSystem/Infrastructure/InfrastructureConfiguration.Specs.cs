namespace PetsLostAndFoundSystem.Infrastructure
{
    using System;
    using System.Reflection;
    using Application.Reporting.Reports;
    using AutoMapper;
    using Common.Persistence;
    using Reporting;
    using FakeItEasy;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class InfrastructureConfigurationSpecs
    {
        [Fact]
        public void AddRepositoriesShouldRegisterRepositories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddDbContext<PetReportingDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddTransient(_ => A.Fake<IReportingDbContext>());

            // Act
            var services = serviceCollection
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddRepositories()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IReportQueryRepository>()
                .Should()
                .NotBeNull();
        }
    }
}
