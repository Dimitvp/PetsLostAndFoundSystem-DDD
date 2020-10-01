namespace PetsLostAndFoundSystem.Domain.Reporting.Factories.Reports
{
    using System;
    using Exceptions;
    using Models.Reports;

    public class ReportFactory : IReportFactory
    {
        private PetStatusType reportStatus = default!;
        private DateTime reportLostDate = default!;
        private string reportImgsLinksPosts = default!;
        private decimal reportRewardSum = default!;
        private Pet reportPet = default!;
        private Location reportLocation = default!;

        private bool petSet = false;
        private bool locationSet = false;

        public Report Build()
        {
            if (!this.petSet || !this.locationSet)
            {
                throw new InvalidReportException("Pet and Location must have a value.");
            }

            return new Report(
                this.reportStatus,
                this.reportLostDate,
                this.reportImgsLinksPosts,
                this.reportRewardSum,
                this.reportPet,
                this.reportLocation,
                true);
        }

        public IReportFactory WithImageUrl(string imgsLinksPosts)
        {
            this.reportImgsLinksPosts = imgsLinksPosts;
            return this;
        }

        public IReportFactory WithLocation(Location location)
        {
            this.reportLocation = location;
            this.locationSet = true;
            return this;
        }

        public IReportFactory WithLocation(string address, double latitude, double longitude)
            => this.WithLocation(new Location(address, latitude, longitude));

        public IReportFactory WithLostDate(DateTime lostDate)
        {
            this.reportLostDate = lostDate;
            return this;
        }

        public IReportFactory WithPet(Pet pet)
        {
            this.reportPet = pet;
            this.petSet = true;
            return this;
        }

        public IReportFactory WithPet(PetType petType, string name, int age, string rfid, string petDescription)
            => this.WithPet(new Pet(petType, name, age, rfid, petDescription));

        public IReportFactory WithRewardSum(decimal rewardSum)
        {
            this.reportRewardSum = rewardSum;
            return this;
        }

        public IReportFactory WithStatus(PetStatusType status)
        {
            this.reportStatus = status;
            return this;
        }
    }
}
