namespace NTT.Core.Entity.Independent;

public class Post
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = null!;
    
    public string Content { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; }
    
    public Guid BlogId { get; set; }
    
    //Navigation property
    public Blog Blog { get; set; } = null!;
}