using MediatR;
using OrderApp.Application.Dtos;
using OrderApp.Application.Services.Abstractions;
using OrderApp.Domain.AggregateModels;
using OrderApp.Domain.Notification;
using OrderApp.Domain.ValueObjects;
using OrderApp.Infrastructure.Repository.Abstractions;

namespace OrderApp.Application.Services
{
    public class OrderService : IOrderService
    {
        public ICustomerRepository CustomerRepository;
        public NotificationContext NotificationContext;
        public IMediator Mediator;
        public OrderService(ICustomerRepository customerRepository, NotificationContext notificationContext, IMediator mediator)
        {
            CustomerRepository = customerRepository;
            NotificationContext = notificationContext;
            Mediator = mediator;
        }

        public bool PlaceOrder(OrderDto orderDto)
        {
            var customer = CustomerRepository.FindByAccountNumberWithLock(orderDto.AccountNumber);

            //TODO Poderia virar um Factory
            var order = CreateOrder(customer, orderDto);

            if (order.Invalid)
            {
                NotificationContext.AddNotifications(order.ValidationResult);
                return false;
            }

            if (customer.CanPlaceOrder(order.OrderValue(), order.Operation))
            {
                customer.PlaceOrder(order);
                //var orderEvent = new PlaceOrderEvent(order);
                //Mediator.Send(orderEvent);
                //TODO Por Domain Event ou via MediatR invocando um Handler
            }

            // TODO Retornar um Response<Order>
            return true;
        }

        private Order CreateOrder(Customer customer, OrderDto orderDto)
        {
            var stock = new Stock { Name = orderDto.Symbol };// TODO Vem do Repositorio
            return new Order(customer.AccountNumber, stock, orderDto.Price, orderDto.Quantity, orderDto.OrderType.Value, orderDto.OperationType.Value);
        }
    }
}
