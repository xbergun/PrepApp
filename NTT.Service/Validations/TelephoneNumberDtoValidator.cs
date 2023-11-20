using FluentValidation;
using NTT.Core.DTOs;

namespace NTT.Service.Validations;

public class TelephoneNumberDtoValidator : AbstractValidator<TelephoneNumberDto>
{
    public TelephoneNumberDtoValidator()
    {
        RuleFor(user => user.TelNo)
            .NotEmpty().WithMessage("Phone number is required")
            .Matches(@"^[0-11]*$").WithMessage("Invalid phone number format");

    }
}