using FluentValidation;
using LIbraryAPI.DTOs.User;

namespace LIbraryAPI.Validator
{
    public class UserDtoValidator: AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x=>x.FIRST_NAME).NotEmpty().WithMessage("FIRST_NAME is required");

            RuleFor(x => x.LAST_NAME).NotEmpty().WithMessage("LAST_NAME is required");

            RuleFor(x => x.ADDRESS).NotEmpty().WithMessage("ADDRESS is required");

            RuleFor(x => x.PHONE_NUMBER).NotEmpty().WithMessage("PHONE_NUMBER is required");
        }
    }
}
