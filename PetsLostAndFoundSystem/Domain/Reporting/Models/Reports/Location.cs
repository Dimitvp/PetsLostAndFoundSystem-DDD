using PetsLostAndFoundSystem.Domain.Common.Models;

namespace PetsLostAndFoundSystem.Domain.Reporting.Models.Reports
{
    public class Location : ValueObject
    {

        internal Location(string address, double latitude, double longitude)
        {
            this.Validate();

            this.Address = address;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
        public string Address { get; }

        public double Latitude { get; }

        public double Longitude { get; }

        private void Validate()
        {

        }
    }
}
