using Microsoft.AspNetCore.Mvc;
using NTT.API.Controllers.Base;
using NTT.Core.DTOs.Custom;
using NTT.Core.DTOs.Custom.Independent.Blog;
using NTT.Service.Abstractions;

namespace NTT.API.Controllers.Independent
{
    public class BlogController : BaseController
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _blogService.GetAllAsync();

            return CreateActionResult(CustomResponseModel<List<BlogResponseModel>>.Success(200, blogs));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] BlogGetByIdRequest request)
        {
            var blog = await _blogService.GetByIdAsync(request);

            return CreateActionResult(CustomResponseModel<BlogResponseModel>.Success(200, blog));
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogCreateRequest request)
        {
            var blog = await _blogService.CreateAsync(request);

            return CreateActionResult(CustomResponseModel<BlogResponseModel>.Success(200, blog));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(BlogDeleteRequest request)
        {
            var isDeleted = await _blogService.DeleteAsync(request);

            return CreateActionResult(CustomResponseModel<bool>.Success(200, isDeleted));
        }
        
        [HttpGet("GetByIdWithPosts/{Id}")]
        public async Task<IActionResult> GetByIdWithPosts([FromRoute] BlogGetByIdRequest request)
        {
            var blog = await _blogService.GetByIdWithPostsAsync(request);

            return CreateActionResult(CustomResponseModel<BlogResponseModelWithPosts>.Success(200, blog));
        }
    }
}