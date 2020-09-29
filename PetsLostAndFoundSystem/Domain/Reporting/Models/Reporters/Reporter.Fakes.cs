namespace PetsLostAndFoundSystem.Domain.Reporting.Models.Reporters
{
    using System.Collections.Generic;
    using System.Linq;
    using Bogus;
    using Common;
    using Common.Models;
    using static Reports.ReportFakes.Data;

    public class ReporterFakes
    {
        public static class Data
        {
            public static IEnumerable<Reporter> GetReporters(int count = 10)
                => Enumerable
                    .Range(1, count)
                    .Select(GetReporter)
                    .ToList();

            public static Reporter GetReporter(int id = 1, int totalReports = 10)
            {
                var reporter = new Faker<Reporter>()
                    .CustomInstantiator(f => new Reporter(
                        $"Dealer{id}",
                        f.Phone.PhoneNumber("+########")))
                    .Generate()
                    .SetId(id);

                foreach (var report in GetReports().Take(totalReports))
                {
                    reporter.AddReport(report);
                }

                return reporter;
            }
        }
    }
}
