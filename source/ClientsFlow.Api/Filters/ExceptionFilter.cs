using ClientsFlow.Communication.Responses;
using ClientsFlow.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ClientsFlow.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            if(context.Exception is ClientsFlowException)
            {
                HandleProjectException(context);
            }
            else
            {
                ThrowUnknowError(context);
            }
        }

        private void HandleProjectException(ExceptionContext context)
        {

            var cashFlowException = context.Exception as ClientsFlowException;
            var errorResponse = new ResponseErrorJson(cashFlowException!.GetErrors());

            context.HttpContext.Response.StatusCode = cashFlowException.StatusCode;
            context.Result = new ObjectResult(errorResponse);
        }
        private void ThrowUnknowError(ExceptionContext context)
        {

            var error = new List<string>();
            error.Add("UnknownError");

            var errorReponse = new ResponseErrorJson(string.Empty)
            {
                ErrorMessage = error

            };

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorReponse);
        }

    }
}
