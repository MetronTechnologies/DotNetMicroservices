using System.Linq.Expressions;
using Blog.Domain.DomainSpecifications;
using Blog.Domain.Extensions;

namespace Blog.Domain.IDomainRepositories;

public interface IGenericRepository<T> where T : class {
    Task AddEntity(T entity);
    Task<T> CreateEntityAsync(T entity);
    Task<List<T>> GetAllAsync();
    Task<T?> GetOneAsync(Expression<Func<T, bool>> expression);
    Task<int> DeleteEntity(Expression<Func<T, bool>> expression);
    Task<bool> UpdateEntity(T entity);
    Task<int> UpdateAsync(int id, T entity);
    Task<IEnumerable<T>> GetAllToList(Expression<Func<T, bool>> expression);
    Task<PaginationHelper<T>> GetAllWithPaging(PaginationDTO paginationDto, Expression<Func<T, bool>> filter, Expression<Func<T, object>> 
        sorter);
}