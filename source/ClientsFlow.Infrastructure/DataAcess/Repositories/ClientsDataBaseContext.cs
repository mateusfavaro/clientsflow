using ClientsFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientsFlow.Infrastructure.DataAcess.Repositories
{
    internal class ClientsDataBaseContext : DbContext
    {

        public ClientsDataBaseContext(DbContextOptions options) : base(options) { }

        // Propriedade responsável por comunicar a entidade com o banco de dados// 
        public DbSet<Client> Clients { get; set; }
    }
}
