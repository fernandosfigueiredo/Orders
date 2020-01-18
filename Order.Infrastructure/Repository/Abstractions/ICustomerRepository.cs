using OrderApp.Domain.AggregateModels;

namespace OrderApp.Infrastructure.Repository.Abstractions
{
    public interface ICustomerRepository
    {
        Customer FindByAccountNumber(string accountNumber);
    }
}
