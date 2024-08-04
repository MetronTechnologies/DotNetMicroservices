using Blog.Application.Services.Interfaces;
using Blog.Domain.Entities;
using Blog.Domain.IDomainRepositories;
using MediatR;

namespace Blog.Application.Blog.Commands.CreateBlog; 

public class CreateBlogCommandHandler: IRequestHandler<CreateBlogCommand, BlogViewModel> {
    
    private readonly IAddOperation _addOperation;
    

    public CreateBlogCommandHandler( IAddOperation addOperation) {
        _addOperation = addOperation;
    }
    
    public async Task<BlogViewModel> Handle(CreateBlogCommand request, CancellationToken cancellationToken) {
        return await _addOperation.AddBlog(request, cancellationToken);
    }
    
}