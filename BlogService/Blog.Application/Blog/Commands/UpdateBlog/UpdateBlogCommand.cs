using MediatR;

namespace Blog.Application.Blog.Commands.UpdateBlog; 

public class UpdateBlogCommand: IRequest<int> {
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Author { get; set; } = default!; 
}