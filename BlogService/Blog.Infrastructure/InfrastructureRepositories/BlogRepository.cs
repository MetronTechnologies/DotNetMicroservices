using Blog.Domain.Entities;
using Blog.Domain.IDomainRepositories;
using Blog.Infrastructure.Data;

namespace Blog.Infrastructure.InfrastructureRepositories; 

public class BlogRepository : GenericRepository<BlogModel>, IBlogRepository {
    
    public BlogRepository(BlogDbContext blogDbContext) : base(blogDbContext) { }
    
}