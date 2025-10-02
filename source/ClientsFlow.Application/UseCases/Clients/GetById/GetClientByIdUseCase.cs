using ClientsFlow.Communication.Responses;
using ClientsFlow.Domain.Entities;
using ClientsFlow.Domain.Repositories.Clients;
using ClientsFlow.Exception.ExceptionBase;

namespace ClientsFlow.Application.UseCases.Clients.GetById
{
    public class GetClientByIdUseCase : IGetClientByIdUseCase
    {

        private readonly IClientsReadOnlyRepository _repository;

        public GetClientByIdUseCase(IClientsReadOnlyRepository repository)
        {
            _repository = repository;
        }


        public async Task<ResponseClientJson> Execute(long id)
        {
            var result = await _repository.GetById(id);

            if (result == null)
            {
                throw new NotFoundException(ResourceErrorMessages.CLIENT_NOT_FOUND);
            }

            return new ResponseClientJson
            {
                Id = result.Id,
                AmountCharged = result.AmountCharged,
                AreaOfActivity = (Communication.Enums.AreaOfActivity)result.AreaOfActivity,
                ClientName = result.ClientName,
                ServiceDescription = result.ServiceDescription  
            };

        }
    }
}
