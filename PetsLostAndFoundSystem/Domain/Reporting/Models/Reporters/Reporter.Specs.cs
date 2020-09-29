namespace PetsLostAndFoundSystem.Domain.Reporting.Models.Reporters
{
    using Reports;
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;

    public class ReporterSpecs
    {
        [Fact]
        public void AddReportShouldSaveReport()
        {
            // Arrange
            var reporter = new Reporter("Valid reporter", "+12345678");
            var report = A.Dummy<Report>();

            // Act
            reporter.AddReport(report);

            // Assert
            reporter.Reports.Should().Contain(report);
        }
    }
}
