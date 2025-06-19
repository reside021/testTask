namespace testTask.Contracts
{
    public record CreateOrderRequest
    {
        public string? CitySender { get; init; }
        public string? AddressSender { get; init; }
        public string? CityRecipient { get; init; }
        public string? AddressRecipient { get; init; }
        public double? Weight { get; init; }
        public DateOnly? DatePickUp { get; init; }
    }
}
