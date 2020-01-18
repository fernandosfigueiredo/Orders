using System.Collections.Generic;
using System.Linq;
using Order.Domain.ValueObjects;

namespace OrderApp.Domain.AggregateModels
{
    public class Custody
    {
        public double Balance { get; set; }
        public IEnumerable<Stock> Stocks { get; set; }

        public double GetCustodyValue()
        {
            var custodySum = Stocks.Sum(stock => stock.Price) + Balance;

            return custodySum;
        }
    }
}
