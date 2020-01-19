using System.Collections.Generic;
using Order.Domain.ValueObjects;
using OrderApp.Domain.AggregateModels;
using OrderApp.Infrastructure.Repository.Abstractions;

namespace OrderApp.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer FindByAccountNumber(string accountNumber)
        {
            //TODO Recuperar o Customer e a Custodia
            return new Customer("12345", "Fernando", "Figueiredo", 123456, CustomerStatusType.OK, new Custody(5000, new List<Stock>()));
        }
    }
}
