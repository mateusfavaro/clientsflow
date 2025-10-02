using ClientsFlow.Communication.Requests;
using ClientsFlow.Communication.Responses;
using ClientsFlow.Domain.Entities;
using ClientsFlow.Domain.Repositories.Clients;

namespace ClientsFlow.Application.UseCases.Clients.Register
{
    public class RegisterClientUseCase : IRegisterClientUseCase
    {

        private readonly IClientsWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;


        public RegisterClientUseCase(IClientsWriteOnlyRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseRegisterClientJson> RegisterClient(RequestClientJson request)
        {

            Validate(request);

            var entity = new Client
            {
                ClientName = request.ClientName,
                AmountCharged = request.AmountCharged,
                ServiceDescription = request.ServiceDescription,
                AreaOfActivity = (Domain.Enums.AreaOfActivity)request.AreaOfActivity,
            };

            await _repository.Add(entity);
            await _unitOfWork.SaveDB();


            var response = new ResponseRegisterClientJson
            {
                ClientName = request.ClientName,
            };

            return response;
        }

        private void Validate(RequestClientJson request)
        {
            var Validator = new RegisterClientsValidator();
            Validator.Validator(request);
        }


    }
}
