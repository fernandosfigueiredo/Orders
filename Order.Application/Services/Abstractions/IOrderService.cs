using OrderApp.Application.Dtos;

namespace OrderApp.Application.Services.Abstractions
{
    public interface IOrderService
    {
        bool PlaceOrder(OrderDto orderDto);
    }
}
