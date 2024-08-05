using Blog.Domain.DomainModels.Request;
using Blog.Domain.DomainModels.Response;
using MediatR;

namespace Blog.Application.Blog.Commands.CreateBlog; 

public class CreateBlogCommand: IRequest<BlogViewRequest> {
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Author { get; set; } = default!;
}