namespace NTT.Core.DTOs.Custom.Independent.Blog;

public class BlogCreateRequest
{
    public string Name { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; }
}