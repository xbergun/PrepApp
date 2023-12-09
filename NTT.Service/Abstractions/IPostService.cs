using NTT.Core.DTOs.Custom.Independent.Post;

namespace NTT.Service.Abstractions;

public interface IPostService
{
    Task<List<PostResponseModel>> GetAllAsync();
    Task<PostResponseModel> GetByIdAsync(PostGetByIdRequest request);
    Task<PostResponseModel> CreateAsync(PostCreateRequest request);
    Task<PostResponseModel> UpdateAsync(PostUpdateRequest request);
    Task<bool> DeleteAsync(PostDeleteRequest request);
}   