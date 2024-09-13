using FluentValidation;
using LIbraryAPI.DTOs.Book;

namespace LIbraryAPI.Validator
{
    public class UpdateDeleteBookDtoValidator: AbstractValidator<BookDto>
    {
        public UpdateDeleteBookDtoValidator()
        {
            RuleFor(x=>x.BOOK_ID).NotEmpty().WithMessage("BOOK_ID must not be null");

            RuleFor(x => x.BOOK_NAME).NotEmpty().WithMessage("BOOK_NAME must not be null");

            RuleFor(x => x.DATE_PUBLISHED).NotEmpty().WithMessage("DATE_PUBLISHED must not be null");
        }
    }
}
