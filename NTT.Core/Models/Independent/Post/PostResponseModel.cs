namespace NTT.Core.DTOs.Custom.Independent.Post;

public class PostResponseModel
{
    public PostResponseModel()
    {
        
    }
    public PostResponseModel(Entity.Independent.Post post)
    {
        Id = post.Id;
        Title = post.Title;
        Content = post.Content;
        BlogId = post.BlogId;
    }
    
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid BlogId { get; set; }
}