using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OrderApp.Domain.Events;

namespace OrderApp.Application.Handlers
{
    public class PlaceOrderHandler : INotificationHandler<PlaceOrderEvent>
    {
        public Task Handle(PlaceOrderEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Im here and i'll place a fuckn order: {notification.Order.Stock.Name}");
            return Task.CompletedTask;
        }
    }
}
