using ClientsFlow.Domain.Entities;

namespace ClientsFlow.Domain.Repositories.Clients
{
    public interface IClientsWriteOnlyRepository
    {

        Task Add(Client client);

        Task<bool> Delete(long id);

    }
}
