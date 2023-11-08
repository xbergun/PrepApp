using NTT.Core.DTOs.Base;

namespace NTT.Core.DTOs;

public class TelephoneNumberDto : BaseDto
{
    public string? TelNo { get; set; }
 
    public int UserId { get; set; }

}