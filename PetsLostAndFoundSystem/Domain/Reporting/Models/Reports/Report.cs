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
            double rewardSum,
            Pet pet,
            Location location,
            bool isApproved)
        {
            this.Validate();

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
            double rewardSum,
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

        public double? RewardSum { get; private set; }

        public Pet Pet { get; private set; }

        public Location Location { get; private set; }

        public bool IsApproved { get; private set; }

        public Report UpdateManufacturer(string manufacturer)
        {
            if (this.Manufacturer.Name != manufacturer)
            {
                this.Manufacturer = new Manufacturer(manufacturer);
            }

            return this;
        }

        public Report UpdateModel(string model)
        {
            this.ValidateModel(model);
            this.Model = model;

            return this;
        }

        public Report UpdateImageUrl(string imageUrl)
        {
            this.ValidateImageUrl(imageUrl);
            this.ImagesLinksPost = imageUrl;

            return this;
        }

        public Report UpdatePricePerDay(decimal pricePerDay)
        {
            this.ValidatePricePerDay(pricePerDay);
            this.PricePerDay = pricePerDay;

            return this;
        }

        public Report UpdateOptions(
            bool hasClimateControl,
            int numberOfSeats,
            TransmissionType transmissionType)
        {
            this.Options = new Options(hasClimateControl, numberOfSeats, transmissionType);

            return this;
        }

        public Report ChangeAprovel()
        {
            this.IsApproved = !this.IsApproved;

            return this;
        }

        private void Validate()
        {
            this.ValidateModel(model);
            this.ValidateImageUrl(imageUrl);
            this.ValidatePricePerDay(pricePerDay);
        }

        private void ValidateModel(string model)
            => Guard.ForStringLength<InvalidReportException>(
                model,
                MinModelLength,
                MaxModelLength,
                nameof(this.Model));

        private void ValidateImageUrl(string imageUrl)
            => Guard.ForValidUrl<InvalidReportException>(
                imageUrl,
                nameof(this.ImagesLinksPost));

        private void ValidatePricePerDay(decimal pricePerDay)
            => Guard.AgainstOutOfRange<InvalidReportException>(
                pricePerDay,
                Zero,
                decimal.MaxValue,
                nameof(this.PricePerDay));
    }
}
