namespace NTT.Core.Entity.Independent;

public class Blog
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string Name { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; }

    //Navigation property
    public List<Post> Posts { get; set; } = new();
    
}