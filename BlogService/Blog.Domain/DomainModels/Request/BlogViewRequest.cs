namespace Blog.Domain.DomainModels.Request; 

public class BlogViewRequest {
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Author { get; set; } = default!;
}