using OrderApp.Domain.AggregateModels;

namespace OrderApp.Application.Dtos
{
    public class OrderDto
    {
        public string AccountNumber { get; set; }
        public string Symbol { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public OrderType? OrderType { get; set; }
        public OperationType? OperationType { get; set; }
    }
}
