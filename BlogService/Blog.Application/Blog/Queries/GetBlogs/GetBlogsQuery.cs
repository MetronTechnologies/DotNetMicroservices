using Blog.Application.Extensions;
using Blog.Domain.DomainModels.Response;
using Blog.Domain.Extensions;
using MediatR;

namespace Blog.Application.Blog.Queries.GetBlogs; 

public class GetBlogsQuery: IRequest<PaginationHelper<BlogViewResponse>> {
    public PaginationDTO PaginationDto { get; set; } = default!;
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Author { get; set; }
}