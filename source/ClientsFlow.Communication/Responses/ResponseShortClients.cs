using ClientsFlow.Communication.Enums;

namespace ClientsFlow.Communication.Responses
{
    public class ResponseShortClients
    {

        public long Id { get; set; }

        public string ClientName { get; set; } = string.Empty;

        public decimal AmountCharged { get; set; }

    }
}
