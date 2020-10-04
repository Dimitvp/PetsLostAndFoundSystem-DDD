namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Commands.Common
{
    using Application.Common;

    public class ReportCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public int Status { get; set; }

        public string ImgsLinksPosts { get; set; } = default!;

        public decimal RewardSum { get; set; }

        public int PetId { get; set; }

        public string LocationAddress { get; set; } = default!;

        public double Longitude { get; set; }

        public double Latitude { get; set; }
    }
}
