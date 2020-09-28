namespace PetsLostAndFoundSystem.Domain.Reporting.Models.Reports
{
    using Common;
    using Common.Models;

    public class PetType : Enumeration
    {
        public static readonly PetType Dog = new PetType(1, nameof(Dog));
        public static readonly PetType Cat = new PetType(2, nameof(Cat));
        public static readonly PetType Bird = new PetType(3, nameof(Bird));
        public static readonly PetType Reptilian = new PetType(4, nameof(Reptilian));
        public static readonly PetType OtherType = new PetType(5, nameof(OtherType));

        private PetType(int value)
            : this(value, FromValue<PetType>(value).Name)
        {
        }

        private PetType(int value, string name)
            : base(value, name)
        {
        }
    }
}
