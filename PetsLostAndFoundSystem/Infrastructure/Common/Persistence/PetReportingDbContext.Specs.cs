namespace PetsLostAndFoundSystem.Infrastructure.Common.Persistence
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Statistics.Handlers;
    using AutoMapper;
    using Reporting;
    using Domain.Reporting.Events.Reporters;
    using Domain.Reporting.Models.Reporters;
    using Domain.Statistics.Models;
    using Events;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Statistics;
    using Xunit;

    public class PetReportingDbContextSpecs
    {
        [Fact]
        public async Task RaisedEventsShouldBeHandled()
        {
            // Arrange
            var services = new ServiceCollection()
                .AddDbContext<PetReportingDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddScoped<IReportingDbContext>(provider => provider
                    .GetService<PetReportingDbContext>())
                .AddScoped<IStatisticsDbContext>(provider => provider
                    .GetService<PetReportingDbContext>())
                .AddTransient<IEventDispatcher, EventDispatcher>()
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddTransient<IEventHandler<ReportAddedEvent>, ReportAddedEventHandler>()
                .AddRepositories()
                .BuildServiceProvider();

            var reporter = ReporterFakes.Data.GetReporter();
            var dbContext = services.GetService<PetReportingDbContext>();

            var statisticsToAdd = new StatisticsData()
                .GetData()
                .First();

            dbContext.Add(statisticsToAdd);
            await dbContext.SaveChangesAsync();

            // Act
            dbContext.Reporters.Add(reporter);
            await dbContext.SaveChangesAsync();

            // Assert
            var statistics = await dbContext.Statistics.SingleAsync();

            statistics.TotalReports.Should().Be(10);
        }
    }
}
