namespace PetsLostAndFoundSystem.Domain.Reporting.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models.Reports;

    public interface IReportDomainRepository
    {
        Task<Report> Find(int id, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);

        Task<Pet> GetPet(
            int petId,
            CancellationToken cancellationToken = default);
    }
}
