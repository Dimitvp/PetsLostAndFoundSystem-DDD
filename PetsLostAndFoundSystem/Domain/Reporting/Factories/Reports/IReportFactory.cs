namespace PetsLostAndFoundSystem.Domain.Reporting.Factories.Reports
{
    using Common;
    using Models.Reports;
    using System;

    public interface IReportFactory : IFactory<Report>
    {
        IReportFactory WithStatus(PetStatusType status);

        IReportFactory WithLostDate(DateTime lostDate);

        IReportFactory WithImageUrl(string imgsLinksPosts);

        IReportFactory WithRewardSum(decimal rewardSum);

        IReportFactory WithPet(Pet pet);

        IReportFactory WithPet(PetType petType,
                    string name,
                    int age,
                    string rfid,
                    string petDescription);

        IReportFactory WithLocation(Location location);

        IReportFactory WithLocation(string address, double latitude, double longitude);
    }
}
