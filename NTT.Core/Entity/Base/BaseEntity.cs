namespace NTT.Core.Entity.Base;

public abstract class BaseEntity
{
    public int Id { get; init; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } 
}