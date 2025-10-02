using ClientsFlow.Domain.Repositories.Clients;
using ClientsFlow.Infrastructure.DataAcess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClientsFlow.Infrastructure
{

    /* Essa classe é a que vai fazer a injeção de dependencia no Program, tendo em vista que as classes injetadas são "private"
     * Dessa forma, a injeção será configurada aqui dentro e essa classe será chamada dentro de program.
     * Essa injeção será tudo relacionado a comunicação com o banco de dados, tendo em vista que heverá outras classes de injeção, porém, elas estarão dentro da pasta
     * respectiva do que será injetado*/

    public static class DependencyInjectionExtension
    {

        public static void AddInfrastructureDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services);
            AddDataBaseContext(services, configuration);
        }


        //Metodo que vai ser chamado no AddInfrastructureDataBase para injetar a interface e a classe que  irá salvar os dados no banco de dados;
        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IClientsReadOnlyRepository, ClientsRepository>();
            services.AddScoped<IClientsWriteOnlyRepository, ClientsRepository>();
            services.AddScoped<IClientsUpdateOnlyRepository, ClientsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }


        /* Metodo que vai injetar a classe que faz a conexão com o banco de dados;
         * Aqui dentro possui as configurações do banco de dados MySQL instalado localmente na maquina;
         */
        private static void AddDataBaseContext(IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("Connect");

            var version = new Version(8, 0, 43);
            var serverVersion = new MySqlServerVersion(version);

            services.AddDbContext<ClientsDataBaseContext>(config => config.UseMySql(connectionString, serverVersion));

        }
    }
}





//PARA HOJE// FAZER A INJEÇÃO DE DEPENDENCIA DO AddRepositories NO USE CASE PARA QUE OS DADOS LÁ PASSADOS SEJAM PERSISTIDOS NO BANCO DE DADOS
// FAZER A CORREÇÃO DA CLASSE QUE SALVA NO BANCO DE DADOS (SAVECHANGES)
// FAZER A INJEÇÃO DE DEPENDENCIA DO USE CASE NO CONTROLLER