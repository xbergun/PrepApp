namespace NTT.Core.DTOs.Custom.Independent.Blog;

public class BlogResponseModel
{
    public BlogResponseModel()
    {
        
    }
    public BlogResponseModel(Entity.Independent.Blog blog)
    {
        Id = blog.Id;
        Name = blog.Name;
        Description = blog.Description;
        CreatedAt = blog.CreatedAt;
    }
    
    public Guid Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; }
}