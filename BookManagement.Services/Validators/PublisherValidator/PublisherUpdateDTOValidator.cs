using BookManagement.Services.Dtos.PublisherDTO;
using FluentValidation;

namespace BookManagement.Services.Validators;

public class PublisherUpdateDTOValidator : AbstractValidator<PublisherUpdateDTO>
{
    public PublisherUpdateDTOValidator()
    {
        RuleFor(p => p.PublisherID)
            .GreaterThan(0)
            .WithMessage("Publisher ID must be a valid positive integer.");

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