using MediatR;

namespace OrderApp.Domain.Events
{
    public class PlaceOrderEvent : INotification
    {
        public AggregateModels.Order Order { get; }

        public PlaceOrderEvent(AggregateModels.Order order)
        {
            Order = order;
        }
    }
}
