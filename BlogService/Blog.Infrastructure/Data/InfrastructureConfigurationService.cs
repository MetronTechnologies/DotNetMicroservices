using Blog.Application.Common.Mappings;
using Blog.Application.Services.Implementations;
using Blog.Application.Services.Interfaces;
using Blog.Domain.IDomainRepositories;
using Blog.Infrastructure.InfrastructureRepositories;
using Blog.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure.Data; 

public static class InfrastructureConfigurationService {
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<BlogDbContext>(
            options => {
                options.UseSqlServer(
                    configuration.GetConnectionString("DBName") ?? throw new
                        InvalidOperationException("Connection String Unavailable")
                );
            });
        services.AddScoped<IBlogServiceSeeder, BlogServiceSeeder>();
        services.AddScoped<IAddOperation, AddOperation>();
        services.AddScoped<IDeleteOperation, DeleteOperation>();
        services.AddScoped<IGetBlogsOperation, GetBlogsOperation>();
        services.AddScoped<IGetByIdOperation, GetByIdOperation>();
        services.AddScoped<IUpdateOperation, UpdateOperation>();
        services.AddTransient<IBlogRepository, BlogRepository>();
        services.AddTransient<IUnitOfWorkRepository, UnitOfWorkRepository>();
        services.AddTransient<IGenericMapper, GenericMapper>();
    }
}