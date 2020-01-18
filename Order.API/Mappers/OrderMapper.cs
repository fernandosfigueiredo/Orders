using OrderApp.API.Models;
using OrderApp.Application.Dtos;

namespace OrderApp.API.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto Map(this OrderModel model, string accountNumber)
        {
            return new OrderDto
            {
                AccountNumber = accountNumber,
                Symbol = model.Symbol,
                Price = model.Price,
                Quantity = model.Price,
                OperationType = model.Operation,
                OrderType = model.Type
            };
        }
    }
}
