namespace NTT.Core.DTOs.Custom.Independent.Blog;

public class BlogUpdateRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

}