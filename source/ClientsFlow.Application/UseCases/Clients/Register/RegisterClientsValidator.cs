using ClientsFlow.Communication.Enums;
using ClientsFlow.Communication.Requests;
using ClientsFlow.Exception.ExceptionBase;

namespace ClientsFlow.Application.UseCases.Clients.Register
{
    public class RegisterClientsValidator
    {

        //Título não pode ser vazio.
        public bool Validator(RequestClientJson request)
        {
            var errorMessages = new List<string>();

            if (string.IsNullOrWhiteSpace(request.ClientName))
            {
                errorMessages.Add(ResourceErrorMessages.REQUIRED_NAME);
            }

            //Valor deve ser maior que zero

            if (request.AmountCharged <= 0)
            {
                errorMessages.Add(ResourceErrorMessages.AMOUNT_CHARGED);
            }

            if (!Enum.IsDefined(typeof(AreaOfActivity), (int)request.AreaOfActivity))
            {
                errorMessages.Add(ResourceErrorMessages.AREA_OF_ACTIVITY);
            }

            if (string.IsNullOrWhiteSpace(request.ServiceDescription))
            {
                errorMessages.Add(ResourceErrorMessages.SERVICE_DESCRIPTION);
            }
            
            //Exception

            if (errorMessages.Any())
            {
                throw new ErrorOnValidationException(errorMessages);
            }
            else
            {
                return false;
            }
        }
    }
}
