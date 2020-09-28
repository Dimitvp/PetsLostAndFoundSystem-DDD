namespace PetsLostAndFoundSystem.Domain.Reporting.Exceptions
{
    using Common;

    public class InvalidReportException : BaseDomainException
    {
        public InvalidReportException()
        {
        }

        public InvalidReportException(string error) => this.Error = error;

    }
}
