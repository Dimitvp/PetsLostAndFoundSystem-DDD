namespace PetsLostAndFoundSystem.Domain.Reporting.Models.Reports
{ 
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;

    public class ReportSpecs
    {
        [Fact]
        public void ChangeAprovelShouldMutateIsApproved()
        {
            // Arrange
            var report = A.Dummy<Report>();

            // Act
            report.ChangeAprovel();

            // Assert
            report.IsApproved.Should().BeFalse();
        }
    }
}
