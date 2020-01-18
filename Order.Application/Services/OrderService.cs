using Order.Domain.ValueObjects;
using OrderApp.Application.Dtos;
using OrderApp.Application.Services.Abstractions;
using OrderApp.Domain.AggregateModels;
using OrderApp.Infrastructure.Repository.Abstractions;

namespace OrderApp.Application.Services
{
    public class OrderService : IOrderService
    {
        public ICustomerRepository CustomerRepository { get; set; }

        public OrderService(ICustomerRepository customerRepository)
        {
            CustomerRepository = customerRepository;
        }

        public bool PlaceOrder(OrderDto orderDto)
        {
            var customer = CustomerRepository.FindByAccountNumber(orderDto.AccountNumber);

            if (!customer.CanDoBuyOrSell())
                return false;

            var order = CreateOrder(customer, orderDto);

            if (customer.CanPlaceOrder(order.OrderValue(), order.Operation))
            {
                //TODO Send a Fuck'n order
                // Por Domain Event ou via MediatR invocando um Handler
            }

            return true;
        }

        private Domain.AggregateModels.Order CreateOrder(Customer customer, OrderDto orderDto)
        {
            var stock = new Stock {Name = orderDto.Symbol};
            return new Domain.AggregateModels.Order(customer.AccountNumber, stock, orderDto.Price, orderDto.Quantity, orderDto.OrderType.Value, orderDto.OperationType.Value);
        }
    }
}
