namespace ClientsFlow.Exception.ExceptionBase
{
    public abstract class ClientsFlowException : System.Exception
    {

        protected ClientsFlowException(string message) : base(message)
        {
            
        }

        public abstract int StatusCode { get; }
        public abstract List<string> GetErrors();

    }
}
