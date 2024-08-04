using System.Collections;
using System.Reflection;

namespace Blog.Application.Common.Mappings;

public class GenericMapper : IGenericMapper {
    public IEnumerable<TDestination> MapCollection<TSource, TDestination>(IEnumerable<TSource> sourceCollection) {
        List<TDestination> destinationList = new List<TDestination>();
        foreach (TSource sourceItem in sourceCollection) {
            TDestination destinationItem = Activator.CreateInstance<TDestination>();
            MapCollections(sourceItem, destinationItem);
            destinationList.Add(destinationItem);
        }

        return destinationList;
    }

    private void MapCollections<TSource, TDestination>(TSource source, TDestination destination) {
        PropertyInfo[] sourceProperties = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        PropertyInfo[] destinationProperties =
            typeof(TDestination).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo sourceProp in sourceProperties) {
            PropertyInfo? destProp = destinationProperties.FirstOrDefault(p => p.Name == sourceProp.Name && p.CanWrite);
            if (destProp != null) {
                object? value = sourceProp.GetValue(source);
                destProp.SetValue(destination, value);
            }
        }
    }

    public TDestination Map<TSource, TDestination>(TSource source) {
        if (source == null) throw new ArgumentNullException(nameof(source));
        TDestination destination = Activator.CreateInstance<TDestination>();
        MapProperties(source, destination);
        return destination;
    }

    private void MapProperties<TSource, TDestination>(TSource source, TDestination destination) {
        PropertyInfo[] sourceProperties = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        PropertyInfo[] destinationProperties =
            typeof(TDestination).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo sourceProp in sourceProperties) {
            PropertyInfo? destProp = destinationProperties.FirstOrDefault(p => p.Name == sourceProp.Name && p.CanWrite);
            if (destProp != null) {
                object? value = sourceProp.GetValue(source);
                destProp.SetValue(destination, value);
            }
        }
    }
    
}