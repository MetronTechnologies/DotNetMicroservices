using System.Reflection;
using Blog.Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace Blog.Application.Extensions; 

public static class ApplicationConfigurationService {

    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        services.AddLogging(loggingBuilders => {
            loggingBuilders.ClearProviders();
            loggingBuilders.AddNLogWeb();
        });
        // services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(
            x => {
                x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                x.AddBehavior(
                    typeof(IPipelineBehavior<,>),
                    typeof(ValidationBehaviour<,>)
                );
            }
        );
        return services;
    }
    
}