using System.Linq.Expressions;
using Blog.Application.Extensions;
using Blog.Domain.Entities;
using Blog.Domain.Extensions;
using Blog.Domain.IDomainRepositories;
using Blog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.InfrastructureRepositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class {
    
    protected BlogDbContext _blogDbContext;
    
    internal DbSet<T> DbSet {
        get; set;
    }
    
    public GenericRepository(BlogDbContext blogDbContext) {
        _blogDbContext = blogDbContext;
        DbSet = _blogDbContext.Set<T>();
    }


    public async Task AddEntity(T entity) {
        await DbSet.AddAsync(entity);
    }

    public async Task<T> CreateEntityAsync(T entity) {
        await DbSet.AddAsync(entity);
        return entity;
    }

    public async Task<List<T>> GetAllAsync() {
        return await DbSet.ToListAsync();
    }

    public async Task<T?> GetOneAsync(Expression<Func<T, bool>> expression) {
        return await DbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(expression);
    }

    public async Task<int> DeleteEntity(Expression<Func<T, bool>> expression) {
        return await DbSet
            .Where(expression)
            .ExecuteDeleteAsync();
    }

    public async Task<bool> UpdateEntity(T entity) {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(int id, T entity) {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> GetAllToList(Expression<Func<T, bool>> expression) {
        throw new NotImplementedException();
    }

    public async Task<PaginationHelper<T>> GetAllWithPaging(int page, int pageSize, Expression<Func<T, bool>> filter, 
        Expression<Func<T, object>> sorter) {
        IQueryable<T> query = DbSet
            .Where(filter)
            .OrderByDescending(sorter);
        return await PaginationHelper<T>.ToPagedList(query, page, pageSize);

        // await Task.FromResult(DbSet.Where(filter)!.OrderByDescending(sorter).ToPagedList());
        // return await DbSet.Where(expression).OrderDescending(sorter).ToPaged
    }
}