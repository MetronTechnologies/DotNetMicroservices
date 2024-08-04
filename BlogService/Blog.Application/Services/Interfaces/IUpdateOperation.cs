using Blog.Application.Blog;
using Blog.Application.Blog.Commands.CreateBlog;
using Blog.Application.Blog.Commands.UpdateBlog;

namespace Blog.Application.Services.Interfaces; 

public interface IUpdateOperation {
    Task<int> UpdateBlog(UpdateBlogCommand request, CancellationToken cancellationToken);
}