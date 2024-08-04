using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Data;



public partial class BlogDbContext: DbContext {
    
    public BlogDbContext(DbContextOptions<BlogDbContext> dbContextOptions): base(dbContextOptions) { }
    
    public DbSet<BlogModel> BlogModel { get; set; }
    
}