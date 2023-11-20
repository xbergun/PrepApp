using NTT.Core.Entity;
using NTT.Service.Models.Users;

namespace NTT.Service.Mapping;

public static class UserMappingHelper
{
    public static UserResponse MapToUserResponse(this User user)
    {
        if (user == null)
            return null;

        return new UserResponse
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Username = user.Username,
            Email = user.Email,
            TcNo = user.TcNo
        };
    }

}