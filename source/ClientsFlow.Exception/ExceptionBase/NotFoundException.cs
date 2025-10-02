using System.Net;

namespace ClientsFlow.Exception.ExceptionBase
{
    public class NotFoundException : ClientsFlowException
    {

        public NotFoundException(string message) : base(message)
        {
            
        }

        public override int StatusCode => (int)HttpStatusCode.NotFound;

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
