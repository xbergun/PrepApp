using NTT.Core.DTOs.Custom.Independent.Blog;

namespace NTT.Service.Abstractions;

public interface IBlogService
{
    Task<BlogResponseModel> GetByIdAsync(BlogGetByIdRequest request);
    Task<List<BlogResponseModel>> GetAllAsync();
    Task<BlogResponseModel> CreateAsync(BlogCreateRequest request);
    Task<BlogResponseModel> UpdateAsync(BlogUpdateRequest request);
    Task<bool> DeleteAsync(BlogDeleteRequest request);
    
    Task<BlogResponseModelWithPosts> GetByIdWithPostsAsync(BlogGetByIdRequest request);
}