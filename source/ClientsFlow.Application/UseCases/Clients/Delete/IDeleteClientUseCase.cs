namespace ClientsFlow.Application.UseCases.Clients.Delete
{
    public interface IDeleteClientUseCase
    {

        Task Execute(long id);

    }
}
