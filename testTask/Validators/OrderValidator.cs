using FluentValidation;
using testTask.Contracts;

namespace testTask.Validators
{
    public class OrderValidator : AbstractValidator<CreateOrderRequest>
    {
        public OrderValidator()
        {
            RuleFor(order => order.CitySender)
                .NotEmpty().WithMessage("Укажите город отправителя");
            RuleFor(order => order.AddressSender)
                .NotEmpty().WithMessage("Укажите адрес отправителя");
            RuleFor(order => order.CityRecipient)
                .NotEmpty().WithMessage("Укажите город получателя");
            RuleFor(order => order.AddressRecipient)
                .NotEmpty().WithMessage("Укажите адрес получателя");
            RuleFor(order => order.Weight)
                .NotNull().WithMessage("Укажите вес груза!")
                .GreaterThan(0).WithMessage("Вес должен быть больше 0!");
            RuleFor(order => order.DatePickUp)
                .NotEmpty().WithMessage("Укажите дату!")
                .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now)).WithMessage("Нельзя выбрать дату забора груза из прошлого!");
        }
    }
}
