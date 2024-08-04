using Blog.Application.Blog;
using Blog.Application.Blog.Commands.CreateBlog;

namespace Blog.Application.Services.Interfaces; 

public interface IAddOperation {
    Task<BlogViewModel> AddBlog(CreateBlogCommand request, CancellationToken cancellationToken);
}