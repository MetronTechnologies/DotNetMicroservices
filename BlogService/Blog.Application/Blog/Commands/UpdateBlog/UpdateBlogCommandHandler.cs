using Blog.Application.Services.Interfaces;
using Blog.Domain.IDomainRepositories;
using MediatR;

namespace Blog.Application.Blog.Commands.UpdateBlog; 

public class UpdateBlogCommandHandler: IRequestHandler<UpdateBlogCommand, int> {
    
    private readonly IUpdateOperation _updateOperation;
    

    public UpdateBlogCommandHandler(IUpdateOperation updateOperation) {
        _updateOperation = updateOperation;
    }
    
    public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken) {
        return await _updateOperation.UpdateBlog(request, cancellationToken);
    }
    
}