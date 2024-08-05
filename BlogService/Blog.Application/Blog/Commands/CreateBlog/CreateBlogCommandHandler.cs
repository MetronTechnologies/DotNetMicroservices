using Blog.Application.Services.Interfaces;
using Blog.Domain.DomainModels.Request;
using Blog.Domain.DomainModels.Response;
using Blog.Domain.Entities;
using Blog.Domain.IDomainRepositories;
using MediatR;

namespace Blog.Application.Blog.Commands.CreateBlog; 

public class CreateBlogCommandHandler: IRequestHandler<CreateBlogCommand, BlogViewRequest> {
    
    private readonly IAddOperation _addOperation;
    

    public CreateBlogCommandHandler( IAddOperation addOperation) {
        _addOperation = addOperation;
    }
    
    public async Task<BlogViewRequest> Handle(CreateBlogCommand request, CancellationToken cancellationToken) {
        return await _addOperation.AddBlog(request, cancellationToken);
    }
    
}