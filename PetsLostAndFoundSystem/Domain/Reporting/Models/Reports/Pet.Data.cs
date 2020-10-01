namespace PetsLostAndFoundSystem.Domain.Reporting.Models.Reports
{
    using System;
    using System.Collections.Generic;
    using Common;

    public class PetData : IInitialData
    {
        public Type EntityType => typeof(Pet);

        public IEnumerable<object> GetData()
            => new List<Pet>
        {
            new Pet(PetType.Dog, "Foxy", 6, "123456789123456", "Foxy like dog, bow"),
            new Pet(PetType.Cat, "Maca", 6, "123456789123456", "Whith and black cat"),
            new Pet(PetType.Bird, "Pepe", 4, "1235456789123456", "Some beautiful, colorful bird with blue tile.")
        };
    }
}
