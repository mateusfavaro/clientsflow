namespace ClientsFlow.Domain.Repositories.Clients
{
    public interface IUnitOfWork
    {

        Task SaveDB();

    }
}
