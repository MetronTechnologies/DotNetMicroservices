using AutoMapper;
using Blog.Application.Blog;
using Blog.Application.Blog.Commands.CreateBlog;
using Blog.Application.Common.Mappings;
using Blog.Application.Services.Interfaces;
using Blog.Domain.DomainModels.Request;
using Blog.Domain.DomainModels.Response;
using Blog.Domain.Entities;
using Blog.Domain.IDomainRepositories;

namespace Blog.Application.Services.Implementations; 

public class AddOperation: IAddOperation {
    
    private readonly IUnitOfWorkRepository _unitOfWorkRepository;
    private readonly IBlogRepository _blogRepository;
    private readonly IGenericMapper _genericMapper;

    public AddOperation(IUnitOfWorkRepository unitOfWorkRepository, IGenericMapper genericMapper) {
        _unitOfWorkRepository = unitOfWorkRepository;
        _blogRepository = _unitOfWorkRepository._IBlogRepo;
        _genericMapper = genericMapper;
    }
    
    public async Task<BlogViewRequest> AddBlog(CreateBlogCommand request, CancellationToken cancellationToken) {
        BlogModel newBlog = new() {
            Author = request.Author,
            Id = 0,
            Name = request.Name,
            Description = request.Description
        };
        BlogModel createdBlog = await _blogRepository.CreateEntityAsync(newBlog);
        await _unitOfWorkRepository.CompleteAsync();
        BlogViewRequest blogViewResponse = _genericMapper.Map<BlogModel, BlogViewRequest>(createdBlog);
        return blogViewResponse;
    }
    
    
}