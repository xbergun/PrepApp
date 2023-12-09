using Microsoft.EntityFrameworkCore;
using NTT.Core.DTOs.Custom.Independent.Post;
using NTT.Core.Entity.Independent;
using NTT.Repository.Context;
using NTT.Service.Abstractions;

namespace NTT.Service.Implementations.Independent;

public class PostService : IPostService
{
    private readonly AppDbContext _context;
    
    public PostService(AppDbContext context)
    {
        _context = context;
    }


    public async Task<List<PostResponseModel>> GetAllAsync()
    {
        return await _context.Posts.Select(p => new PostResponseModel
        {
            Id = p.Id,
            Title = p.Title,
            Content = p.Content,
            BlogId = p.BlogId   
        }).AsNoTracking().ToListAsync();
    }

    public async Task<PostResponseModel> GetByIdAsync(PostGetByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<PostResponseModel> CreateAsync(PostCreateRequest request)
    {
        var post = new Post
        {
            Title = request.Title,
            Content = request.Content,
            BlogId = request.BlogId,
            CreatedAt = DateTime.Now,
        };
        
        await _context.Posts.AddAsync(post);
        
        await _context.SaveChangesAsync();
        
        return new PostResponseModel(post);
    }

    public async Task<PostResponseModel> UpdateAsync(PostUpdateRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(PostDeleteRequest request)
    {
        throw new NotImplementedException();
    }
}