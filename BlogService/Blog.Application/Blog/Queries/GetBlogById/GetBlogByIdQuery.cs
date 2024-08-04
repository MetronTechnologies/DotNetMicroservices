using Blog.Domain.DomainModels.Response;
using MediatR;

namespace Blog.Application.Blog.Queries.GetBlogById; 

public class GetBlogByIdQuery : IRequest<BlogViewResponse> {
    public int BlogId { get; set; }
}