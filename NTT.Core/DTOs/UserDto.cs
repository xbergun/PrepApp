using NTT.Core.DTOs.Base;

namespace NTT.Core.DTOs;

//Entity'lerimizi direkt olarak çekmek yerine bir ara katman yazarak UI katmanının ihtiyacı olmayan fieldleri gormemesini sağlıyoruz.

public class UserDto : BaseDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string TcNo { get; set; } = null!;

}