using ClientsFlow.Domain.Enums;

namespace ClientsFlow.Domain.Entities
{
    public class Client
    {
        public long Id { get; set; }

        public string ClientName { get; set; } = string.Empty;

        public AreaOfActivity AreaOfActivity { get; set; }

        public decimal AmountCharged { get; set; }

        public string ServiceDescription { get; set; } = string.Empty;
    }
}
