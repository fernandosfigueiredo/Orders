using System.Collections.Generic;
using System.Linq;
using OrderApp.Domain.ValueObjects;

namespace OrderApp.Domain.AggregateModels
{
    public class Custody
    {
        public double Balance { get; set; }
        public IEnumerable<Stock> Stocks { get; set; }

        //TODO implementar Builder ou factory

        public Custody(double balance, IEnumerable<Stock> stocks)
        {
            Balance = balance;
            Stocks = stocks;
        }

        public double GetCustodyValue()
        {
            if (Stocks == null)
                return Balance;

            var custodySum = Stocks.Sum(stock => stock.Price) + Balance;

            return custodySum;
        }
    }
}
