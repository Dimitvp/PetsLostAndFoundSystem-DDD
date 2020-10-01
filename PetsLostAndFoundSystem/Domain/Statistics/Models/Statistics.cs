namespace PetsLostAndFoundSystem.Domain.Statistics.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    public class Statistics : IAggregateRoot
    {
        private readonly HashSet<ReportView> reportViews;

        internal Statistics()
        {
            this.TotalReports = 0;

            this.reportViews = new HashSet<ReportView>();
        }

        public int TotalReports { get; private set; }

        public IReadOnlyCollection<ReportView> ReportViews
            => this.reportViews.ToList().AsReadOnly();

        public void AddReport()
            => this.TotalReports++;

        public void AddReportView(int reportId, string? userId)
            => this.reportViews.Add(new ReportView(reportId, userId));
    }
}
