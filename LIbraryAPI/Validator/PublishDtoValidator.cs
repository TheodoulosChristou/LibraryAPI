using FluentValidation;
using LIbraryAPI.DTOs.Publish;

namespace LIbraryAPI.Validator
{
    public class PublishDtoValidator: AbstractValidator<PublishDto>
    {
        public PublishDtoValidator() 
        {
            RuleFor(x => x.BOOK_ID).NotNull().WithMessage("BOOK_ID must not be null");

            RuleFor(x => x.AUTHOR_ID).NotNull().WithMessage("AUTHOR_ID must not be null");
        }

    }
}
