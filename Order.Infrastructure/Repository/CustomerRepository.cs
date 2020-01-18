using OrderApp.Domain.AggregateModels;
using OrderApp.Infrastructure.Repository.Abstractions;

namespace OrderApp.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer FindByAccountNumber(string accountNumber)
        {
            //TODO Recuperar o Customer e a Custodia
            return null;
        }
    }
}
