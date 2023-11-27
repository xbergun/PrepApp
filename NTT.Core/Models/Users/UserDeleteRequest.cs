using FluentValidation;

namespace NTT.Service.Models.Users;

public class UserDeleteRequest
{
    public int Id { get; set; }
}

public class UserDeleteRequestValidator : AbstractValidator<UserDeleteRequest>
{
    public UserDeleteRequestValidator()
    {
        RuleFor(user => user.Id)
            .NotEmpty().WithMessage("Id is required").GreaterThan(0);
    }
}