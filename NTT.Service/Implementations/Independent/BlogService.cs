using Microsoft.EntityFrameworkCore;
using NTT.Core.DTOs.Custom.Independent.Blog;
using NTT.Core.Entity.Independent;
using NTT.Repository.Context;
using NTT.Service.Abstractions;

namespace NTT.Service.Implementations.Independent;

public class BlogService : IBlogService
{
    private readonly AppDbContext _context;
    
    public BlogService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<BlogResponseModel>> GetAllAsync()
    {
        return await _context.Blogs.Select(bl => new BlogResponseModel
        {
            Id = bl.Id,
            Name = bl.Name,
            Description = bl.Description,
            CreatedAt = bl.CreatedAt,
        }).AsNoTracking().ToListAsync();
    }
    
    public async Task<BlogResponseModel> GetByIdAsync(BlogGetByIdRequest request)
    {
        var blog = await _context.Blogs.FindAsync(request.Id);
        
        return new BlogResponseModel(blog);
    }

    public async Task<BlogResponseModel> CreateAsync(BlogCreateRequest request)
    {
        var blog = new Blog
        {
            Name = request.Name,
            Description = request.Description,
            CreatedAt = DateTime.Now,
        };
        
        await _context.Blogs.AddAsync(blog);
        
        await _context.SaveChangesAsync();

        return new BlogResponseModel(blog);
    }

    public async Task<BlogResponseModel> UpdateAsync(BlogUpdateRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(BlogDeleteRequest request)
    {
        var blog = await _context.Blogs.FindAsync(request.Id);
        
         _context.Blogs.Remove(blog);
         
         await _context.SaveChangesAsync();
         
         return true;
    }

    public async Task<BlogResponseModelWithPosts> GetByIdWithPostsAsync(BlogGetByIdRequest request)
    {
        var blog = await _context.Blogs.Include(x => x.Posts).FirstOrDefaultAsync(x => x.Id == request.Id);
        
        return new BlogResponseModelWithPosts(blog);
    }
}