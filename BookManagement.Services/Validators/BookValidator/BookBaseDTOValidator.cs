using FluentValidation;
using BookManagement.Services.Dtos.BookDTO;
using BookManagement.Core.Repositories;
using System.Threading;

namespace BookManagement.Services.Validators.BookValidator;

public class BookBaseDTOValidator : AbstractValidator<BookBaseDTO>
{
    public BookBaseDTOValidator()
    {
        RuleFor(b => b.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .Length(1, 100)
            .WithMessage("Title must be between 1 and 100 characters.");

        RuleFor(b => b.Genre)
            .NotEmpty()
            .WithMessage("Genre is required.")
            .Length(1, 50)
            .WithMessage("Genre must be between 1 and 50 characters.");

        RuleFor(b => b.PublishDate)
            .Must(date => date <= DateTime.UtcNow)
            .WithMessage("Publish date must be in the past.");
    }
}

