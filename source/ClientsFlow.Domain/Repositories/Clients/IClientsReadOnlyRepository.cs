using ClientsFlow.Domain.Entities;

namespace ClientsFlow.Domain.Repositories.Clients
{
    public interface IClientsReadOnlyRepository
    {
        Task<List<Client>> GetAll();

        Task<Client?> GetById(long id);

    }
}
