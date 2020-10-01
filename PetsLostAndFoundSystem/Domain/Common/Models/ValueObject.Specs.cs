namespace PetsLostAndFoundSystem.Domain.Common.Models
{
    using Reporting.Models.Reports;
    using FluentAssertions;
    using Xunit;

    public class ValueObjectSpecs
    {
        [Fact]
        public void ValueObjectsWithEqualPropertiesShouldBeEqual()
        {
            // Arrange
            var first = new Location("Adress", 46.66, 47.77);
            var second = new Location("Adress", 46.66, 47.77);

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeTrue();
        }

        [Fact]
        public void ValueObjectsWithDifferentPropertiesShouldNotBeEqual()
        {
            // Arrange
            var first = new Location("Adress", 46.66, 47.77);
            var second = new Location("Adress", 46.66, 46.66);

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeFalse();
        }
    }
}
