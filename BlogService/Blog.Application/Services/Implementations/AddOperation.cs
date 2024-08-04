using AutoMapper;
using Blog.Application.Blog;
using Blog.Application.Blog.Commands.CreateBlog;
using Blog.Application.Services.Interfaces;
using Blog.Domain.Entities;
using Blog.Domain.IDomainRepositories;

namespace Blog.Application.Services.Implementations; 

public class AddOperation: IAddOperation {
    
    private readonly IUnitOfWorkRepository _unitOfWorkRepository;
    private readonly IBlogRepository _blogRepository;

    public AddOperation(IUnitOfWorkRepository unitOfWorkRepository) {
        _unitOfWorkRepository = unitOfWorkRepository;
        _blogRepository = _unitOfWorkRepository._IBlogRepo;
    }
    
    public async Task<BlogViewModel> AddBlog(CreateBlogCommand request, CancellationToken cancellationToken) {
        BlogModel newBlog = new() {
            Author = request.Author,
            Id = 0,
            Name = request.Name,
            Description = request.Description
        };
        // BlogModel blog = _mapper.Map<BlogModel>(newBlog);
        // BlogModel createdBlog = await _blogRepository.CreateEntityAsync(blog);
        // return _mapper.Map<BlogViewModel>(createdBlog);
        return new BlogViewModel();
    }
    
    
}