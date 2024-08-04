using MediatR;

namespace Blog.Application.Blog.Commands.DeleteBlog; 

public class DeleteBlogCommand : IRequest<int> {
    public int BlogId { get; set; }
}