using AutoMapper;
using Blog.Application.Blog.Commands.DeleteBlog;
using Blog.Application.Services.Interfaces;
using Blog.Domain.IDomainRepositories;

namespace Blog.Application.Services.Implementations; 

public class DeleteOperation : IDeleteOperation {
    
    private readonly IUnitOfWorkRepository _unitOfWorkRepository;
    private readonly IBlogRepository _blogRepository;

    public DeleteOperation(IUnitOfWorkRepository unitOfWorkRepository) {
        _unitOfWorkRepository = unitOfWorkRepository;
        _blogRepository = _unitOfWorkRepository._IBlogRepo;
    }

    public async Task<int> DeleteAsync(DeleteBlogCommand request, CancellationToken cancellationToken) {
        return await _blogRepository.DeleteEntity(b => b.Id == request.BlogId);
    }
    
}