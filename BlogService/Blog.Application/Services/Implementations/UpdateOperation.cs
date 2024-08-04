using AutoMapper;
using Blog.Application.Blog;
using Blog.Application.Blog.Commands.CreateBlog;
using Blog.Application.Blog.Commands.UpdateBlog;
using Blog.Application.Services.Interfaces;
using Blog.Domain.Entities;
using Blog.Domain.IDomainRepositories;

namespace Blog.Application.Services.Implementations; 

public class UpdateOperation: IUpdateOperation {
    
    private readonly IUnitOfWorkRepository _unitOfWorkRepository;
    private readonly IBlogRepository _blogRepository;

    public UpdateOperation(IUnitOfWorkRepository unitOfWorkRepository) {
        _unitOfWorkRepository = unitOfWorkRepository;
        _blogRepository = _unitOfWorkRepository._IBlogRepo;
    }
    
    public async Task<int> UpdateBlog(UpdateBlogCommand request, CancellationToken cancellationToken) {
        // BlogModel blog = _mapper.Map<BlogModel>(request);
        // return await _blogRepository.UpdateAsync(request.Id, blog);
        return 0;
    }
    
    
}