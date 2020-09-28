namespace PetsLostAndFoundSystem.Domain.Reporting.Exceptions
{
    using Common;

    public class InvalidReporterException : BaseDomainException
    {
        public InvalidReporterException()
        {
        }

        public InvalidReporterException(string error) => this.Error = error;
    }
}
