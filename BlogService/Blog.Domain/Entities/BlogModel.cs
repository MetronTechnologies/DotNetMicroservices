namespace Blog.Domain.Entities; 

public class BlogModel {
    public int Id { get; set; } = default;
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Author { get; set; } = default!;
}