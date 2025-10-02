using ClientsFlow.Domain.Entities;
using ClientsFlow.Domain.Repositories.Clients;
using Microsoft.EntityFrameworkCore;

namespace ClientsFlow.Infrastructure.DataAcess.Repositories
{
    internal class ClientsRepository : IClientsWriteOnlyRepository, IClientsReadOnlyRepository, IClientsUpdateOnlyRepository
    {

        private readonly ClientsDataBaseContext _dbContext;

        public ClientsRepository(ClientsDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Client client)
        {
            await _dbContext.Clients.AddAsync(client);

        }

        public async Task<bool> Delete(long id)
        {
            var result = await _dbContext.Clients.FirstOrDefaultAsync(client => client.Id == id);

            if (result == null)
            {
                return false;
            }

            _dbContext.Clients.Remove(result);

            return true;

        }

        public async Task<List<Client>> GetAll()
        {
            
            return await _dbContext.Clients.AsNoTracking().ToListAsync();

        }

        public void Update(Client client)
        {
            _dbContext.Clients.Update(client);
        }

        async Task<Client?> IClientsReadOnlyRepository.GetById(long id)
        {
            return await _dbContext.Clients.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        async Task<Client?> IClientsUpdateOnlyRepository.GetById(long id)
        {
            return await _dbContext.Clients.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
