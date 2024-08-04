using Blog.Application.Blog;
using Blog.Application.Blog.Queries.GetBlogById;
using Blog.Domain.DomainModels.Response;

namespace Blog.Application.Services.Interfaces; 

public interface IGetByIdOperation {
    Task<BlogViewResponse> GetBlogByIdProcess(GetBlogByIdQuery request, CancellationToken cancellationToken);
}