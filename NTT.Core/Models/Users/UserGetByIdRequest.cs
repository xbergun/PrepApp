using FluentValidation;

namespace NTT.Service.Models.Users;

public class UserGetByIdRequest
{
    public Guid Id { get; set; }
}

public class UserGetByIdRequestValidator : AbstractValidator<UserGetByIdRequest>
{
    public UserGetByIdRequestValidator()
    {
        RuleFor(user => user.Id)
            .NotEmpty().WithMessage("Id is required");
    }
}