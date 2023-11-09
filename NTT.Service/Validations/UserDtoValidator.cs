using FluentValidation;
using NTT.Core.DTOs;

namespace NTT.Service.Validations;

public class UserDtoValidator : AbstractValidator<UserDto>
{
    public UserDtoValidator()
    {
        RuleFor(user => user.FirstName)
            .NotEmpty().WithMessage("First name is required")
            .MaximumLength(100).WithMessage("First name cannot be longer than 100 characters");

        RuleFor(user => user.LastName)
            .NotEmpty().WithMessage("Last name is required")
            .MaximumLength(100).WithMessage("Last name cannot be longer than 100 characters")
            .NotEqual(user => user.FirstName).WithMessage("First and last name cannot be the same");

        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email is required")
            .MaximumLength(100).WithMessage("Email cannot be longer than 100 characters")
            .Matches(@"^(.+)@(.+)$").WithMessage("Invalid email format");

        RuleFor(user => user.TcNo)
            .NotEmpty().WithMessage("TC number is required")
            .Length(11).WithMessage("TC number must be 11 characters")
            .Matches(@"^[0-9]*$").WithMessage("Invalid TC number format");
    }
}