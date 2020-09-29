using PetsLostAndFoundSystem.Domain.Common.Models;
using PetsLostAndFoundSystem.Domain.Reporting.Exceptions;

namespace PetsLostAndFoundSystem.Domain.Reporting.Models.Reports
{
    using static ModelConstants.Location;

    public class Location : ValueObject
    {

        internal Location(string address, double latitude, double longitude)
        {
            this.Validate(address, latitude, longitude);

            this.Address = address;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
        public string Address { get; }

        public double Latitude { get; }

        public double Longitude { get; }

        private void Validate(string address, double latitude, double longitude)
        {
            Guard.ForStringLength<InvalidReportException>(
                address,
                MinAddressLength,
                MaxAddressLength,
                nameof(this.Address));
        }
    }
}
