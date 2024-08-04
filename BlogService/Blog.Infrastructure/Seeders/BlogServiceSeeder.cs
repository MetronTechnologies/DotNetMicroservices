using Blog.Domain.Entities;
using Blog.Infrastructure.Data;

namespace Blog.Infrastructure.Seeders; 

public class BlogServiceSeeder: IBlogServiceSeeder {
    
    private readonly BlogDbContext _dbContext;

    public BlogServiceSeeder(BlogDbContext dbContext) {
        _dbContext = dbContext;
    }
    
    public async Task Seed() {
        if (await _dbContext.Database.CanConnectAsync()) {
            if (!_dbContext.BlogModel.Any(x => x.Author == "Clark")) {
                var blogs = GenerateBlogs();
                _dbContext.BlogModel.AddRange(blogs);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
    
    private IEnumerable<BlogModel> GenerateBlogs() {
        return new List<BlogModel>() {
            new() {
                Author = "Clark",
                Description = "Adventures of superman",
                Name = "Clark Blogs"
            },
            new() {
                Author = "Bruce",
                Description = "Adventures of the batman",
                Name = "Wayne Enterprise Daily"
            }
        };
    }
    
}