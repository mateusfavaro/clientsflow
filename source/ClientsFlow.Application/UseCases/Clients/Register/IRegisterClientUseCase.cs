using ClientsFlow.Communication.Requests;
using ClientsFlow.Communication.Responses;

namespace ClientsFlow.Application.UseCases.Clients.Register
{
    public interface IRegisterClientUseCase
    {

        Task <ResponseRegisterClientJson> RegisterClient(RequestClientJson request);

    }
}
