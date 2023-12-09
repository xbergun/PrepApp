namespace NTT.Core.DTOs.Custom.Independent.Post;

public class PostCreateRequest
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public Guid BlogId { get; set; }
}