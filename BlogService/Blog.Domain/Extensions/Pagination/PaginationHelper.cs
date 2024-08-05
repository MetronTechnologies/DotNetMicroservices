using Microsoft.EntityFrameworkCore;

namespace Blog.Domain.Extensions; 

public class PaginationHelper<T> {
    public int CurrentPage { get; private set; }
    public int TotalPages { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
    public IEnumerable<T> Data { get; private set; }

    public PaginationHelper() {
        
    }

    public PaginationHelper(IEnumerable<T> items, int count, int pageNumber, int pageSize) {
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        Data = items;
    }

    public static async Task<PaginationHelper<T>> ToPagedList(IQueryable<T> source, PaginationDTO paginationDto) {
        int pageNumber = paginationDto.page;
        int pageSize = paginationDto.pageSize;
        int count = await source.CountAsync();
        List<T> items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PaginationHelper<T>(items, count, pageNumber, pageSize);
    }
    
}