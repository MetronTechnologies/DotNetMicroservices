using Blog.Application.Blog.Commands.DeleteBlog;

namespace Blog.Application.Services.Interfaces; 

public interface IDeleteOperation {
    Task<int> DeleteAsync(DeleteBlogCommand request, CancellationToken cancellationToken);
}