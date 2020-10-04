namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Commands.Common
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Common.Contracts;
    using Domain.Reporting.Repositories;

    public static class ChangeReportCommandExtensions
    {
        public static async Task<Result> ReporterHasReport(
            this ICurrentUser currentUser,
            IReporterDomainRepository reporterRepository,
            int reportId,
            CancellationToken cancellationToken)
        {
            var reporterId = await reporterRepository.GetReporterId(
                currentUser.UserId,
                cancellationToken);

            var reporterHasReport = await reporterRepository.HasReport(
                reporterId,
                reportId,
                cancellationToken);

            return reporterHasReport
                ? Result.Success
                : "You cannot edit this report.";
        }
    }
}
