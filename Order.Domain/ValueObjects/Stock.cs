namespace Order.Domain.ValueObjects
{
    public class Stock
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int RoundLot { get; set; }
        public double Price { get; set; }
    }
}
