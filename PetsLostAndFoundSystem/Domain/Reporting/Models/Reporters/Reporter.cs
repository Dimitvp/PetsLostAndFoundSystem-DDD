namespace PetsLostAndFoundSystem.Domain.Reporting.Models.Reporters
{
    using System.Collections.Generic;
    using System.Linq;
    using Reports;
    using Common;
    using Common.Models;
    using Events.Reporters;
    using Exceptions;
    using static ModelConstants.Common;

    public class Reporter : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Report> reports;

        internal Reporter(string name, string phoneNumber)
        {
            this.Validate(name);

            this.Name = name;
            this.PhoneNumber = phoneNumber;

            this.reports = new HashSet<Report>();
        }

        private Reporter(string name)
        {
            this.Name = name;
            this.PhoneNumber = default!;

            this.reports = new HashSet<Report>();
        }

        public string Name { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public Reporter UpdateName(string name)
        {
            this.Validate(name);
            this.Name = name;

            return this;
        }

        public Reporter UpdatePhoneNumber(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;

            return this;
        }

        public IReadOnlyCollection<Report> Reports => this.reports.ToList().AsReadOnly();

        public void AddReport(Report report)
        {
            this.reports.Add(report);

            this.RaiseEvent(new ReportAddedEvent());
        }

        private void Validate(string name)
            => Guard.ForStringLength<InvalidReporterException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}