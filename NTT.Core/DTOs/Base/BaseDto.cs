namespace NTT.Core.DTOs.Base;

public abstract class BaseDto
{
    public int Id { get; init; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}