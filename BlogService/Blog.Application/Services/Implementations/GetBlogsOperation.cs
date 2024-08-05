using System.Linq.Expressions;
using AutoMapper;
using Blog.Application.Blog;
using Blog.Application.Blog.Queries.GetBlogs;
using Blog.Application.Common.Mappings;
using Blog.Application.Extensions;
using Blog.Application.Services.Interfaces;
using Blog.Domain.DomainModels.Response;
using Blog.Domain.DomainSpecifications.EntitySpecification;
using Blog.Domain.Entities;
using Blog.Domain.Extensions;
using Blog.Domain.IDomainRepositories;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Blog.Application.Services.Implementations;

public class GetBlogsOperation : IGetBlogsOperation {
    private readonly IUnitOfWorkRepository _unitOfWorkRepository;
    private readonly IBlogRepository _blogRepository;
    private readonly ILogger<GetBlogsOperation> _logger;
    private readonly IGenericMapper _genericMapper;


    public GetBlogsOperation(IUnitOfWorkRepository unitOfWorkRepository, ILogger<GetBlogsOperation> logger,
        IGenericMapper genericMapper) {
        _unitOfWorkRepository = unitOfWorkRepository;
        _blogRepository = _unitOfWorkRepository._IBlogRepo;
        _logger = logger;
        _genericMapper = genericMapper;
    }

    public async Task<PaginationHelper<BlogViewResponse>> GetBlogsProcess(GetBlogsQuery request,
        CancellationToken cancellationToken) {
        BlogModel blogModel = new BlogModel() {
            Author = request.Author,
            Description = request.Description,
            Name = request.Name
        };
        BlogQueryBuilder blogQueryBuilder = new BlogQueryBuilder();
        Expression<Func<BlogModel,bool>> expression = blogQueryBuilder.GetBlogs(blogModel);
        PaginationHelper<BlogModel> allWithPaging = await _blogRepository.GetAllWithPaging(
            request.PaginationDto, expression, (x => x.Description)
        );
        IEnumerable<BlogViewResponse> blogViewModels =
            _genericMapper.MapCollection<BlogModel, BlogViewResponse>(allWithPaging.Data);
        PaginationHelper<BlogViewResponse> response = new PaginationHelper<BlogViewResponse>(blogViewModels,
            allWithPaging.TotalCount, allWithPaging.CurrentPage, allWithPaging.PageSize);
        return response;
    }
}