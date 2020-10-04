namespace PetsLostAndFoundSystem.Application.Statistics.Handlers
{
    using System.Threading.Tasks;
    using Common;
    using Domain.Reporting.Events.Reporters;

    public class ReportAddedEventHandler : IEventHandler<ReportAddedEvent>
    {
        private readonly IStatisticsRepository statistics;

        public ReportAddedEventHandler(IStatisticsRepository statistics)
            => this.statistics = statistics;

        public Task Handle(ReportAddedEvent domainEvent)
            => this.statistics.IncrementCarAds();
    }
}
