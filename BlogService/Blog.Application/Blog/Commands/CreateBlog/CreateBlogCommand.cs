using MediatR;

namespace Blog.Application.Blog.Commands.CreateBlog; 

public class CreateBlogCommand: IRequest<BlogViewModel> {
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Author { get; set; } = default!;
}