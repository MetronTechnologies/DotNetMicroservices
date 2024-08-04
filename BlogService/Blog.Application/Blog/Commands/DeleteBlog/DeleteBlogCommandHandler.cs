using Blog.Application.Services.Interfaces;
using MediatR;

namespace Blog.Application.Blog.Commands.DeleteBlog; 

public class DeleteBlogCommandHandler: IRequestHandler<DeleteBlogCommand, int> {
    private readonly IDeleteOperation _deleteOperation;
    
    public DeleteBlogCommandHandler(IDeleteOperation deleteOperation) {
        _deleteOperation = deleteOperation;
    }
    
    public async Task<int> Handle(DeleteBlogCommand request, CancellationToken cancellationToken) {
        return await _deleteOperation.DeleteAsync(request, cancellationToken);
    }
}