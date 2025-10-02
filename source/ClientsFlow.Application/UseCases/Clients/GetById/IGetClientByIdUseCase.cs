using ClientsFlow.Communication.Responses;

namespace ClientsFlow.Application.UseCases.Clients.GetById
{
    public interface IGetClientByIdUseCase
    {

        Task<ResponseClientJson> Execute(long id);

    }
}
