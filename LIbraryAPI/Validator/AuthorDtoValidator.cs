using FluentValidation;
using LIbraryAPI.DTOs.Author;
using LIbraryAPI.Entity;

namespace LIbraryAPI.Validator
{
    public class AuthorDtoValidator:AbstractValidator<AuthorDto>
    {
        public AuthorDtoValidator() 
        { 
            RuleFor(x=>x.AUTHOR_NAME).NotEmpty().WithMessage("AUTHOR_NAME must not be null");

            RuleFor(x => x.AUTHOR_NAME).Matches("^[a-zA-Z ]*$").WithMessage("AUTHOR_NAME accepts only letters and spaces");

            RuleFor(x => x.AUTHOR_SURNAME).NotEmpty().WithMessage("AUTHOR_SURNAME must not be null");

            RuleFor(x => x.AUTHOR_SURNAME).Matches("^[a-zA-Z ]*$").WithMessage("AUTHOR_SURNAME accepts only letters and spaces");

            RuleFor(x => x.AGE).ExclusiveBetween(0, 100).WithMessage("AGE must be between 0 to 100");

            RuleFor(x => x.AGE).NotNull().WithMessage("AGE must not be null");
        } 
    }
}
