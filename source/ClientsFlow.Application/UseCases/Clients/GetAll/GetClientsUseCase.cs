
using ClientsFlow.Communication.Responses;
using ClientsFlow.Domain.Repositories.Clients;

namespace ClientsFlow.Application.UseCases.Clients.GetAll
{
    public class GetClientsUseCase : IGetClientsUseCase
    {

        private readonly IClientsReadOnlyRepository _repository;

        public GetClientsUseCase(IClientsReadOnlyRepository repository)
        {
            _repository = repository;
        }


        public async Task<ResponseAllClients> Execute()
        {
            var result = await _repository.GetAll();

            return new ResponseAllClients
            {
                Clients = result.Select(c => new ResponseShortClients { Id = c.Id, ClientName = c.ClientName, AmountCharged = c.AmountCharged}).ToList(),
            };
        }
    }
}
