using BookManagement.Services.Dtos.BookDTO;
using FluentValidation;

namespace BookManagement.Services.Validators.AuthorValidator;

public class UpdateBookDTOValidator : AbstractValidator<BookUpdateDTO>
{
    public UpdateBookDTOValidator()
    {
        RuleFor(b => b.BookID).GreaterThan(0);
        RuleFor(b => b.Title).NotEmpty().Length(1, 100);
        RuleFor(b => b.Genre).NotEmpty().Length(1, 50);
        RuleFor(b => b.PublishDate).Must(date => date <= DateTime.UtcNow);
        RuleFor(b => b.PublisherID).GreaterThan(0);
    }
}