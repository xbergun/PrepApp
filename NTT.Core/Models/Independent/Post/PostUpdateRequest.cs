namespace NTT.Core.DTOs.Custom.Independent.Post;

public class PostUpdateRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public Guid BlogId { get; set; }
}