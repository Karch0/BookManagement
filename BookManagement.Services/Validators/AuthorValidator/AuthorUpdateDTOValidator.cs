using BookManagement.Services.Dtos.AuthorDTO;
using FluentValidation;

namespace BookManagement.Services.Validators.AuthorValidator;

public class AuthorUpdateDTOValidator : AbstractValidator<AuthorUpdateDTO>
{
    public AuthorUpdateDTOValidator()
    {
        RuleFor(x => x.AuthorID).GreaterThan(0);
        RuleFor(x => x.FirstName).NotEmpty()
            .WithMessage("First name is required!")
            .Length(1, 50)
            .WithMessage("First name must be between 1 and 50 characters!");

    }
}