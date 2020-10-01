namespace PetsLostAndFoundSystem.Domain.Statistics.Models
{
    using Common.Models;

    public class ReportView : Entity<int>
    {
        internal ReportView(int reportId, string? userId)
        {
            this.ReportId = reportId;
            this.UserId = userId;
        }

        public int ReportId { get; }

        public string? UserId { get; }
    }
}
