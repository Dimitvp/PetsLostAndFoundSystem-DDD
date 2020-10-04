namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Commands.Create
{
    using Common;
    using FluentValidation;

    public class CreateReportCommandValidator : AbstractValidator<CreateReportCommand>
    {
        public CreateReportCommandValidator(IReportQueryRepository reportRepository)
            => this.Include(new ReportCommandValidator<CreateReportCommand>(reportRepository));
    }
}
