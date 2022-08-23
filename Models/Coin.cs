namespace RatesDemo.Models
{
    public class Coin
    {
        public int Id { get; set; }
        public string? Name { get; set; } //the question mark makes it nullable which allows it to be null
        public decimal Price { get; set; }
    }
}
