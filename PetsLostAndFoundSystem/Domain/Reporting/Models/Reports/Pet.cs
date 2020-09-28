using PetsLostAndFoundSystem.Domain.Common.Models;

namespace PetsLostAndFoundSystem.Domain.Reporting.Models.Reports
{
    using Common.Models;
    using Exceptions;
    using static ModelConstants.Common;
    using static ModelConstants.Pet;

    public class Pet : Entity<int>
    {
        internal Pet(
                    PetType petType,
                    string name,
                    int age,
                    string rfid,
                    string petDescription)
        {
            this.Validation(name);

            this.PetType = petType;
            this.Name = name;
            this.Age = age;
            this.RFID = rfid;
            this.PetDescription = petDescription;
        }

        private Pet(
                    string name,
                    int age,
                    string rfid,
                    string petDescription)
        {
            this.Name = name;
            this.Age = age;
            this.RFID = rfid;
            this.PetDescription = petDescription;

            this.PetType = default!;
        }

        public PetType PetType { get;}

        public string Name { get; }

        public int Age { get; }

        public string RFID { get; }

        public string PetDescription { get; }

        private void Validation(string name)
        {
            Guard.ForStringLength<InvalidReportException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
        }
    }
}
