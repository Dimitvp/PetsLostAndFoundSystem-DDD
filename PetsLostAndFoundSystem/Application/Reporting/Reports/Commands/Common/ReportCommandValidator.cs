namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Commands.Common
{
    using System;
    using Application.Common;
    using Domain.Common.Models;
    using Domain.Reporting.Models.Reports;
    using FluentValidation;
    using static Domain.Reporting.Models.ModelConstants.Common;
    using static Domain.Reporting.Models.ModelConstants.Report;

    public class ReportCommandValidator<TCommand> : AbstractValidator<ReportCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public ReportCommandValidator(IReportQueryRepository reportRepository)
        {

        }
    }
}
