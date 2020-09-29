namespace PetsLostAndFoundSystem.Domain.Reporting.Models.Reports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Common.Models;
    using Exceptions;
    using static ModelConstants.Common;
    using static ModelConstants.Report;

    public class Report : Entity<int>, IAggregateRoot
    {
        internal Report(
            PetStatusType status,
            DateTime LostDate,
            string imgsLinksPosts,
            decimal rewardSum,
            Pet pet,
            Location location,
            bool isApproved)
        {
            this.Validate(imgsLinksPosts, rewardSum);

            this.Status = status;
            this.LostDate = LostDate;
            this.ImagesLinksPost = imgsLinksPosts;
            this.RewardSum = rewardSum;
            this.Pet = pet;
            this.Location = location;
            this.IsApproved = isApproved;
        }

        private Report(
            string imgsLinksPosts,
            decimal rewardSum,
            bool isApproved)
        {
            this.LostDate = LostDate;
            this.ImagesLinksPost = imgsLinksPosts;
            this.RewardSum = rewardSum;
            this.IsApproved = isApproved;

            this.Status = default!;
            this.Pet = default!;
            this.Location = default!;
        }

        public PetStatusType Status { get; private set; }

        public DateTime LostDate { get; private set; }

        public string ImagesLinksPost { get; private set; }

        public decimal? RewardSum { get; private set; }

        public Pet Pet { get; private set; }

        public Location Location { get; private set; }

        public bool IsApproved { get; private set; }

        public Report UpdateStatus(PetStatusType status)
        {
            if (this.Status != status)
            {
                this.Status = status;
            }

            return this;
        }

        public Report UpdateImageUrl(string imageUrl)
        {
            this.ValidateImageUrl(imageUrl);
            this.ImagesLinksPost = imageUrl;

            return this;
        }

        public Report UpdateRewardSum(decimal rewardSum)
        {
            this.ValidateRewardSum(rewardSum);
            this.RewardSum = rewardSum;

            return this;
        }

        public Report UpdatePet(
            PetType petType,
            string name,
            int age,
            string rfid,
            string petDescription)
        {
            this.Pet = new Pet(petType, name, age, rfid, petDescription);

            return this;
        }

        public Report UpdateLocation(
            string address,
            double latitude,
            double longitude)
        {
            this.Location = new Location(address, latitude, longitude);

            return this;
        }

        public Report ChangeAprovel()
        {
            this.IsApproved = !this.IsApproved;

            return this;
        }

        private void Validate(string imgsLinksPosts, decimal rewardSum)
        {
            this.ValidateImageUrl(imgsLinksPosts);
            this.ValidateRewardSum(rewardSum);
        }

        private void ValidateImageUrl(string imageUrl)
            => Guard.ForValidUrl<InvalidReportException>(
                imageUrl,
                nameof(this.ImagesLinksPost));

        private void ValidateRewardSum(decimal rewardSum)
            => Guard.AgainstOutOfRange<InvalidReportException>(
                rewardSum,
                Zero,
                decimal.MaxValue,
                nameof(this.RewardSum));
    }
}
