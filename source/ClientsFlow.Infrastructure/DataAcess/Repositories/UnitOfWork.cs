using ClientsFlow.Domain.Repositories.Clients;

namespace ClientsFlow.Infrastructure.DataAcess.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {

        private readonly ClientsDataBaseContext _dbContext;

        public UnitOfWork(ClientsDataBaseContext context)
        {
            _dbContext = context;
        }

        public async Task SaveDB()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
