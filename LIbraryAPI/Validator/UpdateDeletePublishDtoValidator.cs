using FluentValidation;
using LIbraryAPI.DTOs.Publish;

namespace LIbraryAPI.Validator
{
    public class UpdateDeletePublishDtoValidator: AbstractValidator<PublishDto>
    {
        public UpdateDeletePublishDtoValidator() 
        {
            RuleFor(x=>x.PUBLISH_ID).NotNull().WithMessage("PUBLISH_ID must not be null");

            RuleFor(x => x.BOOK_ID).NotNull().WithMessage("BOOK_ID must not be null");

            RuleFor(x => x.AUTHOR_ID).NotNull().WithMessage("AUTHOR_ID must not be null");
        }    
    }
}
