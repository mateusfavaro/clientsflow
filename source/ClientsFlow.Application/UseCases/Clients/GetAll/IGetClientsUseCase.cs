using ClientsFlow.Communication.Responses;

namespace ClientsFlow.Application.UseCases.Clients.GetAll
{
    public interface IGetClientsUseCase
    {
        Task<ResponseAllClients> Execute();
    }
}
