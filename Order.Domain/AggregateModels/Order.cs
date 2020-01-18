using Order.Domain.ValueObjects;

namespace OrderApp.Domain.AggregateModels
{
    //TODO Order parecia ser meu AggregateRoot mas parece mais um ValueObject
    public class Order
    {
        private string AccountNumber { get; }
        private Stock Stock { get; }
        private int Price { get; }
        private int Quantity { get; }
        private OrderType Type { get; }
        public OperationType Operation { get; }

        //TODO Implementar validador / Builder?
        public Order(string accountNumber, Stock stock, int price, int quantity, OrderType type, OperationType operation)
        {
            AccountNumber = accountNumber;
            Stock = stock;
            Price = price;
            Quantity = quantity;
            Type = type;
            Operation = operation;
        }

        public double OrderValue()
        {
            return Price * Quantity;
        }
    }
}
