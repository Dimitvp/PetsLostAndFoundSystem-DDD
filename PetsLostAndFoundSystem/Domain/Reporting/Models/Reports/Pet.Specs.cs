namespace PetsLostAndFoundSystem.Domain.Reporting.Models.Reports
{
    using System;
    using Exceptions;
    using FluentAssertions;
    using Xunit;

    public class PetSpecs
    {
        [Fact]
        public void ValidPetShouldNotThrowException()
        {
            // Act
            Action act = () => new Pet(PetType.Dog, PetFakes.ValidPetName, 5, PetFakes.ValidRFID, "Valid pet description!");

            // Assert
            act.Should().NotThrow<InvalidReportException>();
        }

        [Fact]
        public void InvalidRFIDShouldThrowException()
        {
            // Act
            Action act = () => new Pet(PetType.Dog, PetFakes.ValidPetName, 5,"", "Valid description text");

            // Assert
            act.Should().Throw<InvalidReportException>();
        }
    }
}
