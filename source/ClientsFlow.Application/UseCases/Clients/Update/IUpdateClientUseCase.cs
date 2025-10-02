using ClientsFlow.Communication.Requests;

namespace ClientsFlow.Application.UseCases.Clients.Update
{
    public interface IUpdateClientUseCase
    {

        Task Execute(long id, RequestClientJson request);

    }
}