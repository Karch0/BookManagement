using BookManagement.Services.Dtos.BookDTO;
using BookManagement.Services.Dtos.PublisherDTO;
using FluentValidation;

namespace BookManagement.Services.Validators;

public class PublisherBaseDTOValidator : AbstractValidator<PublisherBaseDTO>
{
    public PublisherBaseDTOValidator() 
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .Length(1, 100)
            .WithMessage("Name must be between 1 and 100 characters.");

        RuleFor(p => p.Address)
            .NotEmpty()
            .WithMessage("Address is required.")
            .Length(1, 200)
            .WithMessage("Address must be between 1 and 200 characters.");
    }
}