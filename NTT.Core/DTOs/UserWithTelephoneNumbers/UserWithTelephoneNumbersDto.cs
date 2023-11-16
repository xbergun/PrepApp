namespace NTT.Core.DTOs;

public class UserWithTelephoneNumbersDto : UserDto
{
    public List<TelephoneNumberDto>? TelephoneNumberDtos { get; set; }
}