using Blog.Application.Blog;
using Blog.Application.Blog.Commands.CreateBlog;
using Blog.Domain.DomainModels.Request;
using Blog.Domain.DomainModels.Response;

namespace Blog.Application.Services.Interfaces; 

public interface IAddOperation {
    Task<BlogViewRequest> AddBlog(CreateBlogCommand request, CancellationToken cancellationToken);
}