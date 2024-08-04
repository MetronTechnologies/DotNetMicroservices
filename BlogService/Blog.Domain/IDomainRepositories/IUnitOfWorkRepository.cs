namespace Blog.Domain.IDomainRepositories;

public interface IUnitOfWorkRepository  {
    
    IBlogRepository _IBlogRepo {
        get; 
    }
    
    Task CompleteAsync();
}