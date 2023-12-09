using Microsoft.AspNetCore.Mvc;
using NTT.API.Controllers.Base;
using NTT.Core.DTOs.Custom;
using NTT.Core.DTOs.Custom.Independent.Post;
using NTT.Service.Abstractions;

namespace NTT.API.Controllers.Independent;

public class PostController : BaseController
{
    private readonly IPostService _postService;
    
    public PostController(IPostService postService)
    {
        _postService = postService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var posts = await _postService.GetAllAsync();

        return CreateActionResult(CustomResponseModel<List<PostResponseModel>>.Success(200, posts));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(PostCreateRequest request)
    {
        var post = await _postService.CreateAsync(request);

        return CreateActionResult(CustomResponseModel<PostResponseModel>.Success(200, post));
    }
}