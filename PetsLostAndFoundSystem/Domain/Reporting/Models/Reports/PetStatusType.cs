namespace PetsLostAndFoundSystem.Domain.Reporting.Models.Reports
{
    using Common;
    using Common.Models;

    public class PetStatusType : Enumeration
    {
        public static readonly PetStatusType Lost = new PetStatusType(1, nameof(Lost));
        public static readonly PetStatusType Found = new PetStatusType(2, nameof(Found));
        public static readonly PetStatusType Reunited = new PetStatusType(3, nameof(Reunited));

        private PetStatusType(int value)
            : this(value, FromValue<PetStatusType>(value).Name)
        {
        }

        private PetStatusType(int value, string name)
            : base(value, name)
        {
        }
    }
}
