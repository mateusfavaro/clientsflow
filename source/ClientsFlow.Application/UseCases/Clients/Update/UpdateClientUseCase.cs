using ClientsFlow.Application.UseCases.Clients.Register;
using ClientsFlow.Communication.Requests;
using ClientsFlow.Domain.Repositories.Clients;
using ClientsFlow.Exception.ExceptionBase;

namespace ClientsFlow.Application.UseCases.Clients.Update
{
    public class UpdateClientUseCase : IUpdateClientUseCase
    {

        private readonly IClientsUpdateOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateClientUseCase(IClientsUpdateOnlyRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(long id, RequestClientJson request)
        {

            Validate(request);

            var result = await _repository.GetById(id);

            if (result == null)
            {
                throw new NotFoundException(ResourceErrorMessages.CLIENT_NOT_FOUND);
            }

            result.ClientName = request.ClientName;
            result.AmountCharged = request.AmountCharged;
            result.ServiceDescription = request.ServiceDescription;
            result.AreaOfActivity = (Domain.Enums.AreaOfActivity)request.AreaOfActivity;

            _repository.Update(result);

            await _unitOfWork.SaveDB();
        }

        private void Validate(RequestClientJson request)
        {
            var Validator = new RegisterClientsValidator();
            Validator.Validator(request);
        }
    }
}
