using NTT.Core.DTOs.Custom.Independent.Post;

namespace NTT.Core.DTOs.Custom.Independent.Blog;

public class BlogResponseModelWithPosts
{
    public BlogResponseModelWithPosts()
    {
        
    }
    public BlogResponseModelWithPosts(Entity.Independent.Blog blog)
    {
        Id = blog.Id;
        Name = blog.Name;
        Description = blog.Description;
        CreatedAt = blog.CreatedAt;
        Posts = blog.Posts.Select(x => new PostResponseModel(x)).ToList();
    }
    
    public Guid Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; }

    public List<PostResponseModel> Posts { get; set; } = new();
}