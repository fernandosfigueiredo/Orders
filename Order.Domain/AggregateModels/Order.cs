using Order.Domain.ValueObjects;
using OrderApp.Domain.BaseModels;
using OrderApp.Domain.Validators;

namespace OrderApp.Domain.AggregateModels
{
    //TODO Order parecia ser meu AggregateRoot mas parece mais um ValueObject
    public class Order : EntityBase
    {
        public string AccountNumber { get; }
        public Stock Stock { get; }
        public int Price { get; }
        public int Quantity { get; }
        public OrderType Type { get; }
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

            Validate(this, new OrderValidator());
        }

        public double OrderValue()
        {
            return Price * Quantity;
        }
    }
}
