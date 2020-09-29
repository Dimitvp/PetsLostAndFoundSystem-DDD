namespace PetsLostAndFoundSystem.Domain.Reporting.Models.Reports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Bogus;
    using Common;
    using Common.Models;
    using FakeItEasy;

    public class ReportSpecs
    {
        public class ReportDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Report);

            public object? Create(Type type) => Data.GetReport();

            public Priority Priority => Priority.Default;
        }

        public static class Data
        {
            public static IEnumerable<Report> GetReports(int count = 10)
                => Enumerable
                    .Range(1, count)
                    .Select(i => GetReport(i))
                    .Concat(Enumerable
                        .Range(count + 1, count * 2)
                        .Select(i => GetReport(i, false)))
                    .ToList();

            public static Report GetReport(int id = 1, bool isApproved = true)
                => new Faker<Report>()
                    .CustomInstantiator(f => new Report(
                       PetStatusType.Lost,
                       DateTime.UtcNow,
                       f.Image.PicsumUrl(),
                       f.Random.Number(100, 200),
                       new Pet(
                           PetType.Dog, 
                           $"Dog{id}", 
                           f.Random.Number(1, 10),
                           f.Random.String(16), 
                           f.Lorem.Letter(10)),
                       A.Dummy<Location>(),
                       isApproved))
                    .Generate()
                    .SetId(id);
        }
    }
}
