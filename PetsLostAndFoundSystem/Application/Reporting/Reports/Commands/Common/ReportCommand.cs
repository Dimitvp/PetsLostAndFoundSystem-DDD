namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Commands.Common
{
    using Application.Common;

    public class ReportCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
    }
}
