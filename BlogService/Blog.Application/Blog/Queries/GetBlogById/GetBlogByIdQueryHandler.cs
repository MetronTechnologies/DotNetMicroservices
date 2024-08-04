using Blog.Application.Services.Interfaces;
using Blog.Domain.DomainModels.Response;
using MediatR;

namespace Blog.Application.Blog.Queries.GetBlogById; 

public class GetBlogByIdQueryHandler: IRequestHandler<GetBlogByIdQuery, BlogViewResponse> {
    private readonly IGetByIdOperation _getByIdOperation;
    
    public GetBlogByIdQueryHandler(IGetByIdOperation getByIdOperation) {
        _getByIdOperation = getByIdOperation;
    }
    
    public async Task<BlogViewResponse> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken) {
        return await _getByIdOperation.GetBlogByIdProcess(request, cancellationToken);
    }
}