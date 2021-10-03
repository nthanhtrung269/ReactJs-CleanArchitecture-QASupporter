using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using QASupporter.Application.Configuration.Behaviors;
using QASupporter.Application.Configuration.Interfaces;
using QASupporter.Application.CqrsHandlers.WriteModels;
using QASupporter.Application.Services;
using QASupporter.Domain.Models;
using System.Reflection;

namespace QASupporter.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Apply the Mediator design pattern for CQRS https://github.com/jbogard/MediatR/wiki
            services.AddMediatR(Assembly.GetExecutingAssembly());
            // Mediatr Pipeline Behaviour: https://github.com/jbogard/MediatR/wiki/Behaviors
            // https://www.codewithmukesh.com/blog/mediatr-pipeline-behaviour/
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehavior<,>));

            // Dependency injection support for Mapster
            // https://github.com/MapsterMapper/Mapster/wiki/Dependency-Injection
            var config = new TypeAdapterConfig();
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            AddMapperConfigurations(config);

            services.AddScoped<ISettingAppService, SettingAppService>();
            services.AddScoped<ICachingService, CachingService>();
            services.AddScoped<IImageService, ImageService>();

            return services;
        }

        private static void AddMapperConfigurations(TypeAdapterConfig config)
        {
            config.NewConfig<FileDto, File>().PreserveReference(true);
            config.NewConfig<File, FileDto>().PreserveReference(true);
        }
    }
}
