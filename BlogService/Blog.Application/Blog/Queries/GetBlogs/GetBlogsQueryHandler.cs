using Blog.Application.Extensions;
using Blog.Application.Services.Interfaces;
using Blog.Domain.DomainModels.Response;
using Blog.Domain.Extensions;
using MediatR;

namespace Blog.Application.Blog.Queries.GetBlogs; 

public class GetBlogsQueryHandler: IRequestHandler<GetBlogsQuery, PaginationHelper<BlogViewResponse>> {

    private readonly IGetBlogsOperation _getBlogsOperation;

    public GetBlogsQueryHandler(IGetBlogsOperation getBlogsOperation) {
        _getBlogsOperation = getBlogsOperation;
    }
    
    public async Task<PaginationHelper<BlogViewResponse>> Handle(GetBlogsQuery request, CancellationToken cancellationToken) {
        return await _getBlogsOperation.GetBlogsProcess(request, cancellationToken);
    }
}