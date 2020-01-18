namespace OrderApp.Domain.AggregateModels
{
    public class Customer
    {
        public string AccountNumber { get; }
        public string Name { get;  }
        public string LastName { get; }
        public int DocumentId { get; }
        public CustomerStatusType Status { get;  }
        public Custody Custody { get;  }

        // TODO Criar validador

        public Customer(string accountNumber, string name, string lastName, int documentId, CustomerStatusType status, Custody custody)
        {
            AccountNumber = accountNumber;
            Name = name;
            LastName = lastName;
            DocumentId = documentId;
            Status = status;
            Custody = custody;
        }

        public bool CanDoBuyOrSell()
        {
            return Status == CustomerStatusType.OK && Custody.GetCustodyValue() > 0;
        }

        public double GetAmountInBalance()
        {
            return Custody.Balance;
        }

        public bool HasFundToOrder(double orderAmount)
        {
            return Custody.Balance >= orderAmount;
        }

        public bool CanPlaceOrder(double orderAmount, OperationType operation)
        {
            if (!CanDoBuyOrSell())
                return false;

            if (operation == OperationType.SELL)
                return true;

            return Custody.Balance >= orderAmount;
        }
    }
}
