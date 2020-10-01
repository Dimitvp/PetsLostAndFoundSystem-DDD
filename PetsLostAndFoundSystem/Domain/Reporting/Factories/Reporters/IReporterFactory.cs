namespace PetsLostAndFoundSystem.Domain.Reporting.Factories.Reporters
{
    using Common;
    using Models.Reporters;

    public interface IReporterFactory : IFactory<Reporter>
    {
        IReporterFactory WithName(string name);

        IReporterFactory WithPhoneNumber(string phoneNumber);
    }
}
