

using Blog.Domain.IDomainRepositories;
using Blog.Infrastructure.Data;

namespace Blog.Infrastructure.InfrastructureRepositories; 

public class UnitOfWorkRepository : IUnitOfWorkRepository{
    
    private readonly BlogDbContext _blogDbContext;
    
    public IBlogRepository _IBlogRepo {
        get; private set;
    }
    
    public UnitOfWorkRepository (BlogDbContext blogDbContext) {
        _blogDbContext = blogDbContext;
        _IBlogRepo = new BlogRepository(blogDbContext);
    }

    public async Task CompleteAsync() {
        await _blogDbContext.SaveChangesAsync();
    }
    
    
}