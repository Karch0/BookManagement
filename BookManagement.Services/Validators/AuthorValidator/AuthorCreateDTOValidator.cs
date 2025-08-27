using BookManagement.Services.Dtos.AuthorDTO;
using FluentValidation;

namespace BookManagement.Services.Validators.AuthorValidator;

public class AuthorCreateDTOValidator : AbstractValidator<AuthorCreateDTO>
{
    public AuthorCreateDTOValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty()
            .WithMessage("First name is required!")
            .Length(1, 50)
            .WithMessage("First name must be between 1 and 50 characters");
        RuleFor(x => x.LastName).NotEmpty()
            .WithMessage("Last name is required!")
            .Length(1, 50)
            .WithMessage("Last name must be between 1 and 50 characters");;
        
    }
}