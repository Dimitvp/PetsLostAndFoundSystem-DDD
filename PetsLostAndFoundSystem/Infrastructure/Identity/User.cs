namespace PetsLostAndFoundSystem.Infrastructure.Identity
{
    using Application.Identity;
    using Domain.Reporting.Exceptions;
    using Domain.Reporting.Models.Reporters;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser, IUser
    {
        internal User(string email)
            : base(email)
            => this.Email = email;

        public Reporter? Reporter { get; private set; }

        public void BecomeReporter(Reporter dealer)
        {
            if (this.Reporter != null)
            {
                throw new InvalidReporterException($"User '{this.UserName}' is already a reporter.");
            }

            this.Reporter = reporter;
        }
    }
}
