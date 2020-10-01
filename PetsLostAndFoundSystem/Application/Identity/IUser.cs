namespace PetsLostAndFoundSystem.Application.Identity
{
    using Domain.Reporting.Models.Reporters;

    public interface IUser
    {
        void BecomeReporter(Reporter reporter);
    }
}
