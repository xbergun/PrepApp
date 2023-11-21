using FluentValidation;

namespace NTT.Service.Models.UserRoles;

public class UserRoleCreateRequest
{
    public int UserId { get; set; }
    public string RoleType { get; set; }
}

public class UserRoleCreateRequestValidator : AbstractValidator<UserRoleCreateRequest>
{
    public UserRoleCreateRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.RoleType).NotEmpty();
    }
}