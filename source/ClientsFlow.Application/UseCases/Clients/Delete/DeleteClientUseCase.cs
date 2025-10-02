
using ClientsFlow.Domain.Repositories.Clients;
using ClientsFlow.Exception.ExceptionBase;

namespace ClientsFlow.Application.UseCases.Clients.Delete
{
    public class DeleteClientUseCase : IDeleteClientUseCase
    {

        private readonly IClientsWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClientUseCase(IClientsWriteOnlyRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(long id)
        {
            
            var result = await _repository.Delete(id);

            if (result == false)
            {
                throw new NotFoundException(ResourceErrorMessages.CLIENT_NOT_FOUND);
            }

            await _unitOfWork.SaveDB();

        }
    }
}
