using FluentValidation;
using BookManagement.Services.Dtos.AuthorDTO;

namespace BookManagement.Services.Validators.AuthorValidator;

public class AuthorBaseDTOValidator : AbstractValidator<AuthorBaseDTO>
{
    public AuthorBaseDTOValidator()
    {
        RuleFor(a => a.FirstName)
            .NotEmpty()
            .WithMessage("First name is required.")
            .Length(1, 50)
            .WithMessage("First name must be between 1 and 50 characters.");

        RuleFor(a => a.LastName)
            .NotEmpty()
            .WithMessage("Last name is required.")
            .Length(1, 50)
            .WithMessage("Last name must be between 1 and 50 characters.");

        RuleFor(a => a.DateOfBirth)
            .Must(date => date <= DateTime.UtcNow.AddYears(-5))
            .WithMessage("Date of birth must be at least 5 years in the past.");

        RuleFor(a => a.Biography)
            .NotEmpty()
            .WithMessage("Biography is required.")
            .MinimumLength(50)
            .WithMessage("Biography must be at least 50 characters long.");
    }
}