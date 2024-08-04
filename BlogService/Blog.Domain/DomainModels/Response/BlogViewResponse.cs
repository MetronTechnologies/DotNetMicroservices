namespace Blog.Domain.DomainModels.Response; 

public class BlogViewResponse {
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Author { get; set; } = default!;
}