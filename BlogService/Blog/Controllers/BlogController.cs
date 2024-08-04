using Blog.Application.Blog;
using Blog.Application.Blog.Commands.CreateBlog;
using Blog.Application.Blog.Commands.DeleteBlog;
using Blog.Application.Blog.Commands.UpdateBlog;
using Blog.Application.Blog.Queries.GetBlogById;
using Blog.Application.Blog.Queries.GetBlogs;
using Blog.Application.Common.Mappings;
using Blog.Application.Extensions;
using Blog.Domain.DomainModels.Response;
using Blog.Domain.Entities;
using Blog.Domain.Extensions;
using Blog.Domain.IDomainRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;


[Route("api/[controller]")]
[ApiController]
public class BlogController: ApiControllerBase {
    private readonly IBlogRepository _blogRepository;
    private readonly IGenericMapper _genericMapper;

    public BlogController(IBlogRepository blogRepository, IGenericMapper genericMapper) {
        _blogRepository = blogRepository;
        _genericMapper = genericMapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBlogsAsync(int pageNumber, int pageSize) {
        PaginationHelper<BlogViewResponse> blogViewModels = await Mediator.Send(new GetBlogsQuery() {
            PageNumber = pageNumber,
            PageSize = pageSize
        });
        return Ok(blogViewModels);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateBlogAsync(CreateBlogCommand command) {
        BlogViewModel blogViewModel = await Mediator.Send(command);
        
        string blogByIdAsyncName = nameof(GetBlogByIdAsync);
        return CreatedAtAction(
            blogByIdAsyncName,
            new { id = blogViewModel.Id },
            blogViewModel
        );
    }
    
    
    [HttpPatch("{blogId}")]
    public async Task<IActionResult> PatchBlogAsync(int blogId, UpdateBlogCommand command) {
        if (blogId != command.Id) {
            return BadRequest();
        }
        await Mediator.Send(command);
        return NoContent();
    }
    
    
    [HttpGet("{id}", Name = "GetBlogByIdAsync")]
    public async Task<IActionResult> GetBlogByIdAsync(int id) {
        BlogViewResponse blogViewModel = await Mediator.Send(new GetBlogByIdQuery(){BlogId = id});
        return blogViewModel == null ? NotFound() : Ok(blogViewModel);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlogByIdAsync(int id) {
        await Mediator.Send(new DeleteBlogCommand(){BlogId = id});
        return NoContent();
    }
    
}