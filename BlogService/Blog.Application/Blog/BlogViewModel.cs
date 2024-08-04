using Blog.Application.Common.Mappings;
using Blog.Domain.Entities;

namespace Blog.Application.Blog; 

public class BlogViewModel {
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Author { get; set; } = default!;
}