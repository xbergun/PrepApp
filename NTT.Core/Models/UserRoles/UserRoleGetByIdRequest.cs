using FluentValidation;

namespace NTT.Service.Models.UserRoles;

public class UserRoleGetByIdRequest
{
    public int UserId { get; set; } = default!;
}

public class UserRoleGetByIdRequestValidator : AbstractValidator<UserRoleGetByIdRequest>
{
    public UserRoleGetByIdRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
    }
}