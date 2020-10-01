namespace PetsLostAndFoundSystem.Domain.Reporting.Models.Reports
{
    using System;
    using FakeItEasy;

    public class PetFakes
    {
        public const string ValidPetName = "Foxy";
        public const string ValidRFID = "123456789123456";

        public class PetDummyFactory : IDummyFactory
        {
            public Priority Priority => Priority.Default;

            public bool CanCreate(Type type) => type == typeof(Pet);

            public object? Create(Type type)
                => new Pet(PetType.Dog, ValidPetName, 5, ValidRFID, "Valid pet description!");
        }
    }
}
