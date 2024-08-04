using Blog.Application.Extensions;
using Blog.Domain.DomainModels.Response;
using Blog.Domain.Extensions;
using MediatR;

namespace Blog.Application.Blog.Queries.GetBlogs; 

public class GetBlogsQuery: IRequest<PaginationHelper<BlogViewResponse>> {
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}