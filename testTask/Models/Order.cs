namespace testTask.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CitySender { get; set; } = null!;
        public string AddressSender { get; set; } = null!;
        public string CityRecipient { get; set; } = null!;
        public string AddressRecipient { get; set; } = null!;
        public double Weight { get; set; }
        public DateOnly DatePickUp { get; set; }
    }
}
