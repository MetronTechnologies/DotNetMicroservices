using Blog.Application.Blog;
using Blog.Application.Blog.Queries.GetBlogs;
using Blog.Application.Extensions;
using Blog.Domain.DomainModels.Response;
using Blog.Domain.Extensions;

namespace Blog.Application.Services.Interfaces; 

public interface IGetBlogsOperation {
    Task<PaginationHelper<BlogViewResponse>> GetBlogsProcess(GetBlogsQuery request, CancellationToken cancellationToken);
}