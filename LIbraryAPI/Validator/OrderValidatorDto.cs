using FluentValidation;
using LIbraryAPI.DTOs.Order;

namespace LIbraryAPI.Validator
{
    public class OrderValidatorDto:AbstractValidator<OrderDto>
    {
        public OrderValidatorDto()
        {
            RuleFor(x => x.USER_ID).NotNull().WithMessage("USER_ID must not be null");

            RuleFor(x => x.BOOK_ID).NotNull().WithMessage("BOOK_ID must not be null");
        }
    }
}
