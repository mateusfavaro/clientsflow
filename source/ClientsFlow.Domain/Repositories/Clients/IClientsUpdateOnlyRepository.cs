using ClientsFlow.Domain.Entities;

namespace ClientsFlow.Domain.Repositories.Clients
{
    public interface IClientsUpdateOnlyRepository
    {
        Task<Client?> GetById(long id);

        void Update(Client client);

    }
}
