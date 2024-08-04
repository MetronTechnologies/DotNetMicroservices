namespace Blog.Application.Common.Mappings; 

public interface IGenericMapper {
    IEnumerable<TDestination> MapCollection<TSource, TDestination>(IEnumerable<TSource> sourceCollection);
    TDestination Map<TSource, TDestination>(TSource source);
    
}