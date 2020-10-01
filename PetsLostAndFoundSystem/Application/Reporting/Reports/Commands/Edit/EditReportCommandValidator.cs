namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Commands.Edit
{
    using Common;
    using FluentValidation;

    public class EditReportCommandValidator : AbstractValidator<EditReportCommand>
    {
        public EditReportCommandValidator(IReportQueryRepository reportRepository)
            => this.Include(new ReportCommandValidator<EditReportCommand>(reportRepository));
    }
}
