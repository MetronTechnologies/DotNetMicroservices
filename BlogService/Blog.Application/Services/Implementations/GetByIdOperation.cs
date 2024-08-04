using AutoMapper;
using Blog.Application.Blog;
using Blog.Application.Blog.Queries.GetBlogById;
using Blog.Application.Common.Mappings;
using Blog.Application.Services.Interfaces;
using Blog.Domain.DomainModels.Response;
using Blog.Domain.Entities;
using Blog.Domain.IDomainRepositories;

namespace Blog.Application.Services.Implementations; 

public class GetByIdOperation: IGetByIdOperation {

    private readonly IUnitOfWorkRepository _unitOfWorkRepository;
    private readonly IBlogRepository _blogRepository;
    private readonly IGenericMapper _genericMapper;

    public GetByIdOperation(IUnitOfWorkRepository unitOfWorkRepository, IGenericMapper genericMapper) {
        _unitOfWorkRepository = unitOfWorkRepository;
        _blogRepository = _unitOfWorkRepository._IBlogRepo;
        _genericMapper = genericMapper;
    }
    
    
    public async Task<BlogViewResponse> GetBlogByIdProcess(GetBlogByIdQuery request, CancellationToken cancellationToken) {
        BlogModel? byIdAsync = await _blogRepository.GetOneAsync(b => b.Id == request.BlogId);
        BlogViewResponse blogViewModel = _genericMapper.Map<BlogModel, BlogViewResponse>(byIdAsync!);
        return blogViewModel;
    }
    
    
}