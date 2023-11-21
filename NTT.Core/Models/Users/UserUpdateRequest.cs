using FluentValidation;
using NTT.Core.Entity;

namespace NTT.Service.Models.Users;

public class UserUpdateRequest
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Username { get; set; }

    public string Email { get; set; }
    
    public string TcNo { get; set; }
}

public class UserUpdateRequestValidator : AbstractValidator<UserUpdateRequest>
{
    public UserUpdateRequestValidator()
    {
        RuleFor(user => user.Id)
            .NotEmpty().WithMessage("Id is required").GreaterThan(0);

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
            .EmailAddress().WithMessage("Not Valid Email Address");

        RuleFor(user => user.TcNo)
            .NotEmpty().WithMessage("TC number is required")
            .Length(11).WithMessage("TC number must be 11 characters")
            .Matches(@"^[0-11]*$").WithMessage("Invalid TC number format");
        
    }
}