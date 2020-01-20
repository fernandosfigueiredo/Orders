using OrderApp.Domain.AggregateModels;

namespace OrderApp.Infrastructure.Repository.Abstractions
{
    public interface ICustomerRepository
    {
        Customer FindByAccountNumberWithLock(string accountNumber);
    }
}
