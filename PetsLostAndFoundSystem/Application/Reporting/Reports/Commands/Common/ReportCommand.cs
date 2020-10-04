namespace PetsLostAndFoundSystem.Application.Reporting.Reports.Commands.Common
{
    using Application.Common;
    using System;

    public class ReportCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public int Status { get; set; }

        public DateTime LostDate { get; set; }

        public string ImgsLinksPosts { get; set; } = default!;

        public decimal RewardSum { get; set; }

        public int PetId { get; set; }

        public int PetType { get; set; }

        public string Name { get; set; } = default!;

        public int Age { get; set; }

        public string Rfid { get; set; } = default!;

        public string PetDescription { get; set; } = default!;

        public string LocationAddress { get; set; } = default!;

        public double Longitude { get; set; }

        public double Latitude { get; set; }
    }
}
