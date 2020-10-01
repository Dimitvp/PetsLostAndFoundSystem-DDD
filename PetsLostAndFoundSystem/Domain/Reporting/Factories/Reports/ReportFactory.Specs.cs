namespace PetsLostAndFoundSystem.Domain.Reporting.Factories.Reports
{
    using System;
    using Exceptions;
    using FluentAssertions;
    using Models.Reports;
    using Xunit;

    public class ReportFactorySpecs
    {
        [Fact]
        public void BuildShouldThrowExceptionIfPetIsNotSet()
        {
            // Assert
            var reportFactory = new ReportFactory();

            // Act
            Action act = () => reportFactory
                .WithStatus(PetStatusType.Lost)
                .WithLostDate(DateTime.UtcNow)
                .WithImageUrl("https://someImage.url")
                .WithRewardSum(100)
                .WithLocation("Valid address", 42.636207, 23.369780)
                .Build();

            // Assert
            act.Should().Throw<InvalidReportException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfLocationIsNotSet()
        {
            // Assert
            var reportFactory = new ReportFactory();

            // Act
            Action act = () => reportFactory
                .WithStatus(PetStatusType.Lost)
                .WithLostDate(DateTime.UtcNow)
                .WithImageUrl("https://someImage.url")
                .WithRewardSum(100)
                .WithPet(PetType.Dog, PetFakes.ValidPetName, 5, PetFakes.ValidRFID, "valid pet descrition")
                .Build();

            // Assert
            act.Should().Throw<InvalidReportException>();
        }

        [Fact]
        public void BuildShouldCreateReportIfEveryPropertyIsSet()
        {
            // Assert
            var reportFactory = new ReportFactory();

            // Act
            var report = reportFactory
                .WithStatus(PetStatusType.Lost)
                .WithLostDate(DateTime.UtcNow)
                .WithImageUrl("https://someImage.url")
                .WithRewardSum(100)
                .WithPet(PetType.Dog, PetFakes.ValidPetName, 5, PetFakes.ValidRFID, "valid pet descrition")
                .WithLocation("Valid address", 42.636207, 23.369780)// Check this coordinates ;) 
                .Build();

            // Assert
            report.Should().NotBeNull();
        }
    }
}
